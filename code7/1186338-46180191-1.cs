    private void CacheUpdate(CacheEntryUpdateArguments args)
    {
        // if expired or evicted, put it back in!
        if (args.RemovedReason == CacheEntryRemovedReason.Expired || args.RemovedReason == CacheEntryRemovedReason.Evicted)
        {
           args.UpdatedCacheItem = new CacheItem(args.Key, "value");
           args.UpdatedCacheItemPolicy = new CacheItemPolicy();
        }
    }
