    public void Stop()
    {
    	lock (logQueue)
    	{
    		if (stopRequest) return;
    		stopRequest = true;
    		Monitor.Pulse(logQueue);
    	}
    }
