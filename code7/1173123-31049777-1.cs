    public async Task<int> GetFirstCompletedTaskAsync()
    {
    	var tasks = new List<Task> 
    	{
    		Task.Run(() =>
    		{
    			Thread.Sleep(5000);
    			return 1;
    		}),
    		Task.Run(() =>
    		{
    			Thread.Sleep(2000);
    			throw new Exception("My error");
    		}),
    		Task.Run(() =>
    		{
    			Thread.Sleep(4000);
    			return 3;
    		}),
    	};
    	
    	while (tasks.Count > 0)
    	{
    		var finishedTask = await Task.WhenAny(tasks);
    		if (finishedTask.Status == TaskStatus.RanToCompletion)
    		{
    			return finishedTask
    		}
    		
    		tasks.Remove(finishedTask);
    	}
        throw new WhateverException("No completed tasks");
    }
