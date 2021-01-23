    private void PopulateCache(Widget value)
    {
		var policy = new CacheItemPolicy();
		policy.UpdateCallback = CacheUpdate;
		_cache.Set(GetCacheItemKey(value), value, policy);
    }
    private void CacheUpdate(CacheEntryUpdateArguments args)
	{
		// if expired or evicted, put it back in!
		if (args.RemovedReason == CacheEntryRemovedReason.Expired || args.RemovedReason == CacheEntryRemovedReason.Evicted)
		{
			_cache.Set(args.Key, _cache[args.Key], CacheItemPolicy);
		}
		// if removed or ChangeMonitorChanged, do nothing
	}
