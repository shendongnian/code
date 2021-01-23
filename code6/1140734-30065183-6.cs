    bool quit = false;
    void Start()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        //Rotate 90 deg
        transform.Rotate(new Vector3(90, 0, 0), Space.World);
    
        //Wait for 4 seconds
        float waitTime = 4;
        yield return wait(waitTime);
    
        //Rotate 40 deg
        transform.Rotate(new Vector3(40, 0, 0), Space.World);
    
        //Wait for 2 seconds
        waitTime = 2;
        yield return wait(waitTime);
    
        //Rotate 20 deg
        transform.Rotate(new Vector3(20, 0, 0), Space.World);
    }
    
    IEnumerator wait(float waitTime)
    {
        float counter = 0;
    
        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            Debug.Log("We have waited for: " + counter + " seconds");
            if (quit)
            {
                //Quit function
                yield break;
            }
            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }
    }
