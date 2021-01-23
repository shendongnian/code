    var responseTask = client.someRemoteCall(request);
    
    responseTask.ContinueWith(t =>
    {
    	switch (t.Status)
    	{
    		case TaskStatus.Faulted:
    			foreach (var exception in t.Exception.Flatten().InnerExceptions)
    			{
    				log.Error(exception.Message);
    
    				if (exception.InnerException != null)
    				{
    					log.Error(exception.InnerException.Message);
    				}
    			}
    			break;
    		case TaskStatus.RanToCompletion:
    			{your success code}
    		default:
    			{some deafult error is thrown}
    	}
    });
