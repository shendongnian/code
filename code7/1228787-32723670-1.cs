    public void MainMethod1()
    {
    	synchronizationLock.EnterReadLock();
    	bool releaseLock = true;
    	try
    	{
    		SubMethod1();
    		SubMethod2();
    		RunWorkerCompletedEventHandler onRunWorkerCompleted = null;
    		onRunWorkerCompleted = (sender, e) =>
    		{
    			((BackgroundWorker)sender).RunWorkerCompleted -= onRunWorkerCompleted;
    			synchronizationLock.ExitReadLock();
    		};
    		myBackgroundWorker.RunWorkerCompleted += onRunWorkerCompleted;
    		myBackgroundWorker.RunWorkerAsync();
    		releaseLock = false;
    	}
    	finally
    	{
    		if (releaseLock)
    			synchronizationLock.ExitReadLock();
    	}
    }
