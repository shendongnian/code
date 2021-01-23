    using UnityEngine; 
    using System.Collections; 
    using UnityEngine.UI; 
    using UnityEngine.SceneManagement;
    
    public class TestScript : MonoBehaviour 
    { 
        public MyClockScript myClock; 
        public ScoreManagerScript scoremanager; 
        public int scoreToReach = 99; // change this value to what you want 
        public int leastscore = 50; 
        public string nextScene = "FY"; // change this value to what you want
    
        void Update () 
        { 
            if (myClock.m_leftTime <= scoreToReach) && (nextScene != "")) 
            { 
                SceneManager.LoadScene(nextScene); 
            } 
            else if ((ScoreManagerScript.score >= scoreToReach) && (nextScene != "")) 
            { 
                ; // put your code here
            } 
        } 
    }  
