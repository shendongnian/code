    _configurationProxy.Invoke("ChangePort", port)
    	.ContinueWith(task =>
    	{
    		if (task.IsFaulted)
    		{
    			Console.WriteLine("ChangePort faulted: {0}", task.Exception.Flatten());	
    		}
    
    		_hubConnection.Stop();
    		_hubConnection.Dispose();
    		_hubConnection = null;
    	}).Wait();
