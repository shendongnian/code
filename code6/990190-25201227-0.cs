    public static T GetCacheItem<T>(String key, Func<string, T> cachePopulate)
    {
        // TODO: Try to get it from the cache
        // But if not...
        T result = cachePopulate(key);
        // TODO: Cache it
        return result;
    }
