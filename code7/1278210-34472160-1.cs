	private const EvictionIntervalMinutes = 10;
	public Data GetData(Credential credential)
	{
		Lazy<Data> newLazy = new Lazy<Data>(
		() => GetDataInternal(credential),
		LazyThreadSafetyMode.ExecutionAndPublication);
		
		CacheItemPolicy evictionPolicy = new CacheItemPolicy
		{ 
			AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(EvictionIntervalMinutes)
		};
		
		var result = MemoryCache.Default.AddOrGetExisting(
			new CacheItem(credential.ToString(), newLazy), evictionPolicy);
			
		var lazy = (Lazy<Data>) result.Value;
		return lazy.Value;
	}
	
