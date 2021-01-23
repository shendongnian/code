    class Class1
    {
    	public async Task SomeTaskAsync(CancellationToken cancellationToken)
    	{
    		for (int i = 0; i < 5; i++)
    		{
    			if (cancellationToken.IsCancellationRequested)
    				break;
    			// Doing some job
    			await Task.Delay(2000);
    		}
    	}
    }
    
    class Class2
    {
    	public async Task ContinuouslyTaskAsync(CancellationToken cancellationToken)
    	{
    		while (!cancellationToken.IsCancellationRequested)
    		{
    			// Doing some job on background
    			await Task.Delay(1000);
    		}
    	}
    }
