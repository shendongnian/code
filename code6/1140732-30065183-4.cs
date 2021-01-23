    void Start()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        //Rotate 90 deg
        transform.Rotate(new Vector3(90, 0, 0), Space.World);
    
        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(4);
    
        //Rotate 40 deg
        transform.Rotate(new Vector3(40, 0, 0), Space.World);
    
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);
    
        //Rotate 20 deg
        transform.Rotate(new Vector3(20, 0, 0), Space.World);
    }
