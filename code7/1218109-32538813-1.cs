	// Load the cache as a static singleton so all of the threads
	// use the same instance.
	private static IMicroCache<string> stringCache = 
        new MicroCache<string>(System.Runtime.Caching.MemoryCache.Default);
	public string GetData(string key)
	{
		return stringCache.GetOrAdd(
			key,
			() => LoadData(key),
			() => LoadCacheItemPolicy(key));
	}
	private string LoadData(string key)
	{
		// Load data from persistent source here
        return "some loaded string";
	}
	private CacheItemPolicy LoadCacheItemPolicy(string key)
	{
		var policy = new CacheItemPolicy();
		// This ensures the cache will survive application
		// pool restarts in ASP.NET/MVC
		policy.Priority = CacheItemPriority.NotRemovable;
		policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1);
		// Load Dependencies
		// policy.ChangeMonitors.Add(new HostFileChangeMonitor(new string[] { fileName }));
		return policy;
	}
