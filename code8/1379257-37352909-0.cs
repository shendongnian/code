        using UnityEngine;
        using System.Collections;
        
        public class RandomiseBackGround : MonoBehaviour
    {
    
        public SpriteRenderer BackgroundSpriteRenderer;
        public Sprite[] backgroundSprites;
    
        // Use this for initialization
        void Start()
        {
            int dayStart = 7;
            int dayStop = 22;
            if(DateTime.Now.Hour > dayStart && DateTime.Now.Hour < dayStop)
            {
                //Display background by day
            }else
            {
                //Display background by night
            }
        }
