    float timer = 0;
    bool timerReached = false;
    
    void Update()
    {
        if (!timerReached)
            timer += Time.deltaTime;
    
        if (!timerReached && timer > 5)
        {
            Debug.Log("Done waiting");
            feedDog();
    
            //Set to false so that We don't run this again
            timerReached = true;
        }
    }
    
    void feedDog()
    {
        Debug.Log("Now feeding Dog");
    }
