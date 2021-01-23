    private void runJobThread(string strBox, string strJob)
    {
        // CODE ...
    	
    	Thread thrSapCall = new Thread(() =>
    	{
    		try { sapLocFunction.Call(); }
    		catch { /* Do nothing */ }
    	});
    
    	thrSapCall.Start();
    
    	while (thrSapCall.IsAlive)
    	{
    		Thread.Sleep(1000);
    		try
    		{
    			if (fw.fileExists(fw.appGetPath + "\\cancel"))
    			{
    				sapLocFunction = null;
    				sapLocTable = null;
    				sapConn.Logoff();
    				sapConn = null;
    				canceled = true;
    				break;
    			}
    		}
    		finally { /* Do nothing */ }
    	}
    
    	thrSapCall = null;
    
    	// CODE ...
    }
