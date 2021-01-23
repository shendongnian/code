    public async Task<T> GetAsync<T>(string key, Func<Task<T>> populator, TimeSpan expire, object parameters)
    {
        if (parameters != null)
            key += JsonConvert.SerializeObject(parameters);
        lock (_cache)
        {
            if (!_cache.Contains(key))
            {
                var lazy = new Lazy<Task<T>>(populator, true);
                _cache.Add(key, lazy, DateTimeOffset.Now.Add(expire));
            }
        }
        return await ((Lazy<Task<T>>)_cache.Get(key)).Value;
    }
