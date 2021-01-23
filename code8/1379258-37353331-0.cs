    using UnityEngine;
    using System.Collections;
    using System;
    
          public SpriteRenderer BackgroundSpriteRenderer;
            public Sprite DayBackground;
            public Sprite NightBackground;
        
        	// Use this for initialization
        	void Start ()
            {
                int dayStart = 7;
                int dayStop = 22;
                if (DateTime.Now.Hour > dayStart && DateTime.Now.Hour < dayStop)
                {
                    //Display background by day
                    BackgroundSpriteRenderer.sprite = DayBackground;
                }
                else
                {
                    //Display background by night**strong text**
                    BackgroundSpriteRenderer.sprite = NightBackground;
                }
            }
        }
