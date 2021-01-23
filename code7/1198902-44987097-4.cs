    //Add NuGet package: Microsoft.Extensions.Caching.Memory    
    using Microsoft.Extensions.Caching.Memory;
    MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
	public Task<T> GetOrAddAsync<T>(
       string key, Func<Task<T>> factory, Action<ICacheEntry> expirationSetter)
	{    
		return _cache.GetOrCreateAsync(key, async cacheEntry => 
		{
			expirationSetter(cacheEntry);
			return await factory().ConfigureAwait(false);
		});
	}
