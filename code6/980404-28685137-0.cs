    public static class LazyEvaluationTesting
    {
    	private static readonly ConcurrentDictionary<int, CustomLazy<CacheableItem>>
    		cacheableItemCache = new ConcurrentDictionary<int, CustomLazy<CacheableItem>>();
    
    	private static CacheableItem RetrieveCacheableItem(int itemId)
    	{
    		Console.WriteLine("--RETRIEVE called\t ItemId [{0}] ThreadId [{1}]", itemId, Thread.CurrentThread.ManagedThreadId);
    		return new CacheableItem
    		{
    			ItemId = itemId
    		};
    	}
    
    	private static void GetCacheableItem(int itemId)
    	{
    		Console.WriteLine("GET called\t ItemId [{0}] ThreadId [{1}]", itemId, Thread.CurrentThread.ManagedThreadId);
    
    		CacheableItem cacheableItem = cacheableItemCache
    			.GetOrAdd(itemId,
    				x => new CustomLazy<CacheableItem>(
    					() => RetrieveCacheableItem(itemId)
    				)
    			).Value;
    
    		//CacheableItem cacheableItem2 = cacheableItemCache
    		//	.GetOrAdd(itemId,
    		//		new CustomLazy<CacheableItem>(
    		//			() => RetrieveCacheableItem(itemId)
    		//		)
    		//	).Value;
    	}
    
    	public static void TestLazyEvaluation()
    	{
    		int[] itemIds = { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
    		ParallelOptions options = new ParallelOptions
    		{
    			MaxDegreeOfParallelism = 75
    		};
    
    		Parallel.ForEach(itemIds, options, itemId =>
    		{
    			GetCacheableItem(itemId);
    			GetCacheableItem(itemId);
    			GetCacheableItem(itemId);
    			GetCacheableItem(itemId);
    			GetCacheableItem(itemId);
    		});
    	}
    
    	private class CustomLazy<T> : Lazy<T> where T : class
    	{
    		public CustomLazy(Func<T> valueFactory)
    			: base(valueFactory)
    		{
    			Console.WriteLine("-Lazy Constructor called  ThreadId [{0}]", Thread.CurrentThread.ManagedThreadId);
    		}
    	}
    
    	private class CacheableItem
    	{
    		public int ItemId { get; set; }
    	}
    }
