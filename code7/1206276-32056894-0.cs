    ManualResetEvent mre = new ManualResetEvent();
    
    public void OnOneThread()
    {
        //Block here until "OnAnotherThread" is done
        mre.WaitOne();
    }
    
    public void OnAnotherThread()
    {
        DoWork();
        //Release the other thread
        mre.Set();
    }
