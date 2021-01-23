    public override CacheItem AddOrGetExisting(CacheItem item, CacheItemPolicy policy)
    {
        if (item == null)
            throw new ArgumentNullException("item");
        return new CacheItem(item.Key, AddOrGetExistingInternal(item.Key, item.Value, policy));
    }
