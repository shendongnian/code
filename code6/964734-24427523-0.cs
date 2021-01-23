    long _requestInProcess;
    void ExecuteGetNewCodeCommand( ArgType args)
    {
        if( 0 < System.Threading.Interlocked(ref _requestInProcess) )
            return; //log something
        try
        {
            System.Threading.Interlocked.Increment(ref _requestInProcess);
            // Execute your command code here
     
        }
        finally
        {
             System.Threading.Interlocked.Decrement(ref _requestInProcess);
        }       
     }
