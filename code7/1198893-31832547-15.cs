    public Task<T> GetAsync<T>(string key, Func<Task<T>> populator, TimeSpan expire, object parameters)
    {
        if (parameters != null)
            key += JsonConvert.SerializeObject(parameters);
        var lazy = ((Lazy<Task<T>>)_cache.Get(key));
        if (lazy != null) return lazy.Value;
        lock (_cache)
        {
            if (!_cache.Contains(key))
            {
                lazy = new Lazy<Task<T>>(populator, true);
                _cache.Add(key, lazy, DateTimeOffset.Now.Add(expire));
                return lazy.Value;
            }
            return ((Lazy<Task<T>>)_cache.Get(key)).Value;
        }
    }
