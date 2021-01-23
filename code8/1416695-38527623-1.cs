    bool keepProcessing;
    UnityThreading.ActionThread myThread;
    void Start()
    {
        keepProcessing = true;
        //Create Thread once
        myThread = UnityThreadHelper.CreateThread(() =>
        {
            while (keepProcessing)
            {
                //Do heavy computing stuff 
    
                //Computing Done! Do something with the output data
                 UnityThreadHelper.Dispatcher.Dispatch(() =>
                  {
                       //You can safely call Unity API functions inside this codeblock
                  }
    
                //Wait so that Unity won't Freeze
                Thread.Sleep(1);
            }
        });
    }
    
    void stopProcessing()
    {
        keepProcessing = false;
        myThread.Abort();
    }
