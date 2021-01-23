    private int batchSize = 10;
    private Queue<int> queue = new Queue<int>();
    		
    private void AddMarket(params int[] marketIDs)
    {
    	lock (queue)
    	{
    		foreach (var marketID in marketIDs)
    		{
    			queue.Enqueue(marketID);
    		}
    				
    		if (queue.Count >= batchSize)
    		{
    			Monitor.Pulse(queue);
    		}
    	}
    }
    
    private void Start()
    {
    	for (var tid = 0; tid < 3; tid++)
    	{
    		Task.Run(async () =>
    		{
    			while (true)
    			{
    				List<int> toProcess;
    
    				lock (queue)
    				{
    					if (queue.Count < batchSize)
    					{
    						Monitor.Wait(queue);
    						continue;
    					}
    
    					toProcess = new List<int>(batchSize);
    					for (var count = 0; count < batchSize; count++)
    					{
    						toProcess.Add(queue.Dequeue());
    					}
    
    					if (queue.Count >= batchSize)
    					{
    						Monitor.Pulse(queue);
    					}
    				}
    
    				var marketData = await GetMarketData(toProcess);
    			}
    		});
    	}
    }
