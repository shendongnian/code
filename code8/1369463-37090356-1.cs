       using UnityEngine;
       using UnityEngine.UI;
       using System.Collections;
                            
         public class BeeCoinScore: MonoBehaviour
          {
                            	  
           public static BeeCoinScore instance;
           public static int coin = 0;  
           public int currentCoin = 0;
           string totalCoinKey = "totalCoin";
                            
           Text CoinScore; // Reference to the Text component.
                            
                            
           void Awake ()
           {
           // Set up the reference.
           CoinScore = GetComponent <Text> ();
                            
           }
           public void Start(){
                            		
           //Get the highScore from player prefs if it is there, 0 otherwise.
           coin = PlayerPrefs.GetInt(totalCoinKey, 0);    
           }
           public void AddBeeCoinScore (int _point) {
                            
           coin += _point;
           GetComponent<Text> ().text = "Bee Coins: " + coin;
                            
           }
                            
           public void TakeBeeCoinScore (int _point) {
                            
           coin -= _point;
           GetComponent<Text> ().text = "Bee Coins: " + coin;
                            
           }
                            
                            
           void Update ()
           {
           // Set the displayed text to be the word "Score" followed by the score value.
           CoinScore.text = "Bee Coins: " + coin;
           }
                            
                            
           void OnDisable(){
                           
           PlayerPrefs.SetInt(totalCoinKey, coin);
           PlayerPrefs.Save();
           
        }
    }
