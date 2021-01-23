        float timeLeft = 10f;
        bool isGazed;
        GameObject GUIv2;
        void Start()
        {
            GUIv2 = GameObject.Find("GUIv2");
        }
    
        void Update()
        {
            if (Hit == InfoCube)
            {
                if (!isGazed)
                {
                    // first frame where gaze was detected.
                    isGazed = true;
                    GUIv2.SetActive(true);
                }
                // Gaze on object.
                return;
            }
            if (Hit != InfoCube && isGazed)
            {
                // first frame where gaze was lost.
                isGazed = false;
                timeLeft = 10f;
                return;
            }
            
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GUIv2.SetActive(false);
            }
        }
