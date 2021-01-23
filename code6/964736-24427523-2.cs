    object _myLock = new object();
    void ExecuteGetNewCodeCommand( ArgType args)
    {
        try
        {
            var result = Monitor.TryEnter( _myLock); // This method returns immediately
            if( !result)  // check if the lock is acquired. 
                return;
            // Execute your command code here
     
        }
        finally
        {
             if(result)     // release the lock.
                 Monitor.Exit(_myLock);
        }       
     }
