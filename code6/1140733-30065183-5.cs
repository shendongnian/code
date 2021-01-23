    bool quit = false;
    void Start()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        float counter = 0;
        //Rotate 90 deg
        transform.Rotate(new Vector3(90, 0, 0), Space.World);
    
        //Wait for 4 seconds
        float waitTime = 4;
        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            Debug.Log("We have waited for: " + counter + " seconds");
            //Wait for a frame so that Unity doesn't freeze
            //Check if we want to quit this function
            if (quit)
            {
                //Quit function
                yield break;
            }
            yield return null;
        }
    
        //Rotate 40 deg
        transform.Rotate(new Vector3(40, 0, 0), Space.World);
    
        //Wait for 2 seconds
        waitTime = 2;
        //Reset counter
        counter = 0;
        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            Debug.Log("We have waited for: " + counter + " seconds");
            //Check if we want to quit this function
            if (quit)
            {
                //Quit function
                yield break;
            }
            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }
    
        //Rotate 20 deg
        transform.Rotate(new Vector3(20, 0, 0), Space.World);
    }
