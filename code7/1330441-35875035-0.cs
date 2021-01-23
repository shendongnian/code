    AutoResetEvent _waitHandle = new AutoResetEvent(true);
    public void SendDataToExternalDevice()
    {
        // do some work;
    
        
        // release the lock.
        _waitHandle.Set();
    
        // may be some more work to do
    }
    public void SendMoreDataToExternalDevice()
    {
        _waitHandle.WaitOne();
        // maye be wait addtional time here  ?
        
        // do send data;
    }
