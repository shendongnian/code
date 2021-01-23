    public static EventHandler CreateDelayedEventHandler(EventHandler<EventArgs> handler, TimeSpan delay)
    {
    	object lockObject = new object();
    
    	return (s, e) =>
    	{
    		Task.Run(() =>
    		{
    			lock (lockObject)
    			{
    				Monitor.PulseAll(lockObject);
    				if (!Monitor.Wait(lockObject, delay))
    				{
    					handler(s, e);
    				}
    			}
    		});
    	};
    }
