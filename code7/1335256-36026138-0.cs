    using UnityEngine;
    using System.Collections;
    using UnityEngine.Advertisements;
    
    //GameOver page when the plane is destroyed
    public class GameOverPage : MonoBehaviour {
    
    public GUISkin skin; //skin for button styles
    public static int start; //static integer indicates to show or hide
    bool showAd = true; //Will show ad the first time
    public static bool running; //static variable indicates if the plane is destroyed or not
    
    
    void OnGUI(){
                GUI.skin = skin;
    
                //if start is not equal to 0 and running is false then show GameOver page buttons
            if ((StartPage.start != 0) && !PlaneMovement.running) {
              if(showAd){ //Check if we should show add           
                if (Advertisement.IsReady ()) {
                Advertisement.Show ();
                showAd = false; //Set to false So that we dont show ad again
              }
          }
    
    
            if (GUI.Button (new Rect (Screen.width / 2.378f, Screen.height / 1.34f, Screen.width / 6f, Screen.height / 10.10f), "", skin.GetStyle ("Restart"))) {  
                                Application.LoadLevel (1);  
                                PlaneMovement.running = true;
                        }
            if (GUI.Button (new Rect (Screen.width / 1.50f, Screen.height / 1.34f, Screen.width / 6.0f, Screen.height / 10.1f), "", skin.GetStyle ("Home"))) {
                                Application.LoadLevel (0);  
                                PlaneMovement.running = false;
                                StartPage.start = 0;
                        }
            if (GUI.Button (new Rect (Screen.width / 5.7f, Screen.height / 1.34f, Screen.width / 6f, Screen.height / 10.10f), "", skin.GetStyle ("Website"))) {
                                Application.OpenURL ("http://www.skyboxertech.weebly.com");
                        }
    
    
            }
        }
    }
