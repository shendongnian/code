    public Text GUIHit;
    public int HitCounter = 0;
    bool firstRun = true;
    
    float waitTimeBeforeDisabling = 2f;
    float timer = 0;
    
    void Update()
    {
        //Check when Button is Pressed
        if (Input.GetMouseButtonDown(1))
        {
            //Reset Timer each time  there is a right click
            timer = 0;
    
            if (!firstRun)
            {
                firstRun = true;
                GUIHit.enabled = true;
            }
    
            HitCounter++;
            GUIHit.text = HitCounter.ToString();
        }
    
        //Button is not pressed
        else
        {
            //Increement timer if Button is not pressed and timer < waitTimeBeforeDisabling
            if (timer < waitTimeBeforeDisabling)
            {
                timer += Time.deltaTime;
            }
    
            //Timer has reached value to Disable Text
            else
            {
                if (firstRun)
                {
                    firstRun = false;
                    GUIHit.text = HitCounter.ToString();
                    HitCounter = 0;
                    GUIHit.enabled = false;
                }
            }
    
        }
    }
