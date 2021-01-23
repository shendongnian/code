    public static void LogAsyncError(this Task task, [LocalizationRequired(false)] string message = null)
    {
    	if (task == null)
    	{
    		return;
    	}
    
    	task.ContinueWith(t =>
    	{
    		var log = Logger.Create("Task error logger");
    
    		if (string.IsNullOrEmpty(message))
    		{
    			log.Error(t.Exception);
    		}
    		else
    		{
    			log.Error(message, t.Exception);
    		}
    	}, TaskContinuationOptions.OnlyOnFaulted);
    }
