    using UnityEngine;
    using System.Collections;
    public class IncreaseDamage : MonoBehaviour {
         private int damage;
         private int math;
         private float money;
         private float math2;
         void Update(){
             money = PlayerPrefs.GetFloat("score");
         }
         public void increaseDamage(){
             money = PlayerPrefs.GetFloat("score");
             if(money >= 45){
                 damage = PlayerPrefs.GetInt("damage");
                 math = damage + 5;
                 PlayerPrefs.SetInt("damage",math);
                 math2 = money - 45;
                 PlayerPrefs.SetFloat("score",math2);
             }
         }
     }
