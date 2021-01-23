    public static async Task<bool> Wait(uint Milliseconds, Func<Task<bool>> Function)
    {
    	var StartTime = Environment.TickCount;
    
    	do
    	{
    		if (await Function())
    		{
    			return true;
    		}
    
    		Thread.Yield();
    	}
    	while (Environment.TickCount < StartTime + Milliseconds);
    
    	return false;
    }
