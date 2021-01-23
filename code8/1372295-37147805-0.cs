    public void Add(logEntry logEntry)
    {
    	lock (logQueue)
    	{
    		if (stopRequest) return;
    		logQueue.Enqueue(logEntry);
    		if (logQueue.Count == 1)
    			Monitor.Pulse(logQueue);
    	}
    }
