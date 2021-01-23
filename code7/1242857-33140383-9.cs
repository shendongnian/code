    object _locker = new object();
    const int SomeTimeout=1000;
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
    	if (!Monitor.TryEnter(_locker, SomeTimeout))
    	{
    		throw new TimeoutException("Oh darn");
    	}
    
    	try
    	{
    		// we have the lock so do something
    	}
    	finally
    	{
    		// must ensure to release the lock safely
    		Monitor.Exit(_locker);
    	}   
    }
