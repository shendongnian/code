    var _jobStorage = JobStorage.Current;
    
    // How to get recurringjobs
    using (var connection = _jobStorage.GetConnection())
    {
    	var storageConnection = connection as JobStorageConnection;
    
    	if (storageConnection != null)
    	{
    		var recurringJob = storageConnection.GetRecurringJobs();
    
    		foreach(var job in recurringJob)
    		{
    			// do you stuff
    		}
    	}
    }
    
    // How to get Servers
    
    var monitoringApi = _jobStorage.GetMonitoringApi();
    var serverList = monitoringApi.Servers();
    
    foreach( var server in serverList)
    {
        // do you stuff with the server
    	// you can use var connection = _jobStorage.GetConnection()
    	// to remove server
    }
