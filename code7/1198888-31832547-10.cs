    public Task<T> GetAsyncEser5<T>(string key, Func<Task<T>> populator, TimeSpan expire, object parameters)
    {
        if (parameters != null)
            key += JsonConvert.SerializeObject(parameters);
        var task = (Task<T>)_cache.Get(key);
        if (task != null) return task;
        _cache.AddOrGetExisting(key, populator(), DateTimeOffset.Now.Add(expire));
        return (Task<T>)_cache.Get(key);
    }
