    //Add NuGet package: Microsoft.Extensions.Caching.Memory    
    using Microsoft.Extensions.Caching.Memory;
    MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
	public Task<T> GetOrAddAsync<T>(
       string key, Func<Task<T>> factory, Action<ICacheEntry, T> expirationSetter)
	{    
		return _cache.GetOrCreateAsync(key, async cacheEntry => 
		{
			var value = await factory();
			expirationSetter(cacheEntry, value);
			return value;
		});
	}
