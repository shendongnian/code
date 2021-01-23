    //Add NuGet package: Microsoft.Extensions.Caching.Memory    
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Primitives;
    MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    public Task<T> GetOrAddAsync<T>(
            string key, Func<Task<T>> factory, Func<T, TimeSpan> expirationCalculator)
	{    
		return _cache.GetOrCreateAsync(key, async cacheEntry => 
		{
			var cts = new CancellationTokenSource();
			cacheEntry.AddExpirationToken(new CancellationChangeToken(cts.Token));
			var value = await factory().ConfigureAwait(false);
			cts.CancelAfter(expirationCalculator(value));
			return value;
		});
	}
