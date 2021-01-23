    public void CrawlItems(ItemQueue itemQueue)
    {
    	Parallel.ForEach(
    		itemQueue,
    		new ParallelOptions {MaxDegreeOfParallelism = 4},
    		item =>
    		{
    			worker.Url = item;
    			/* Some work */
    		 });
    }
