    public System.Collections.IEnumerable coroutineFunction()
    {
    
        while (!doneYourPersistentProcess())
        // ... wait for it ...
        yield return "";
        // now it is done.
        doPostProcessing();
    
    }
    
    public void doPostProcessing()
    {
        // Loading progressbar here
    }
    
    public void Update()
    {
        if (userStartsPersistentProcess())
            StartCoroutine(coroutineFunction());
    
    }
    
    public bool userStartsPersistentProcess()
    {
        // your code here.
    }
    
    public bool doneYourPersistentProcess()
    {
        // your code here.
    }
