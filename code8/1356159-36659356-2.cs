    private ObjectCache _cache = MemoryCache.Default;
    private object _lock = new object();
    // NOTE: The country parameter would typically be a database key type,
    // (normally int or Guid) but you could still use it to build a unique key using `.ToString()`.
    public IEnumerable<StateOrProvinceDto> GetCachedStateOrProvinceList(string country)
    {
        // Key can be any string, but it must be both 
        // unique across the cache and deterministic
        // for this function.
        var key = "GetCachedStateList" + country;
        // Try to get the object from the cache
        var stateOrProvinceList = _cache[key] as IEnumerable<StateOrProvinceDto>;
        // Check whether the value exists
        if (stateOrProvinceList == null)
        {
            lock (_lock)
            {
                // Try to get the object from the cache again
               stateOrProvinceList = _cache[key] as IEnumerable<StateOrProvinceDto>;
                // Double-check that another thread did 
                // not call the DB already and load the cache
                if (stateOrProvinceList == null)
                {
                    // Get the list from the DB
                    stateOrProvinceList = GetStateOrProvinceList()
                    // Add the list to the cache
                    _cache.Set(key, stateOrProvinceList, DateTimeOffset.Now.AddMinutes(5));
                }
            }
        }
        // Return the cached list
        return stateOrProvinceList;
    }
