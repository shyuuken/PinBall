using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアを加算する
    private int score ;

    //スコアを表示する
    private GameObject scoreCounterText;
 



    //Use this for initialization
    void Start()
    {
        //初期スコアを代入して表示
        score = 0;

        //シーン中のGameObjectTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のGameObjectTextオブジェクトを取得
        this.scoreCounterText = GameObject.Find("ScoreCounter");

    }

 
    //Update is called once per frame
    void Update()
    {
        {
            // scoreCounterTextに獲得したスコアを表示
            this.scoreCounterText.GetComponent<Text>().text = "SCORE  " + score;
        }

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "GameOver!";
        }

        // 得点の表示更新処理はここより下に書いてはダメ
    }

    //ボールが衝突したときにスコアを加算する
    void OnCollisionEnter(Collision collision)
    {
        //衝突したタグによって加算する点数を変える
        if (collision.gameObject.tag == "SmallStarTag")
        {
            //星小に衝突したら+10
            this.score += 10;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            //星大に衝突したら+50
            this.score += 50;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            //雲小に衝突したら+30
            this.score += 30;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            //雲大に衝突したら+100
            this.score += 100;
        }
        Debug.Log(score);
    }
}
