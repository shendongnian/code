    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Countdown : MonoBehaviour
    {
        float timeLeft = 30.0f;
        public Text text;
        public Text scoretext;
        public Text finalscore;
        public AudioSource ping;
        public GameObject ball;
        bool timerStarted = false;
        // Use this for initialization
        void Start ()
        {
            finalscore.text = "";        
        }
    
        void countdownfunction()
        {
            timeLeft -= Time.deltaTime;
            text.text = "Time Left: " + Mathf.Round(timeLeft) + " seconds";
        }
    
        // Update is called once per frame
        void Update ()
        {
            if(Input.GetMouseButtonDown(0))
                timerStarted = true;
            if(timerStarted)
                countdownfunction();
    
            if (timeLeft < 0)
            {
                ping = GetComponent<AudioSource>();
                text.text = "Time's up!";
                ping.Play();
                ball.SetActive(false);
                finalscore.text = "Final score ^";            
            }
        }
    }
