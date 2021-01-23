    public Task<T> GetAsync<T>(string key, Func<Task<T>> populator, TimeSpan expire, object parameters)
    {
        if (parameters != null)
            key += JsonConvert.SerializeObject(parameters);
        var task = (Task<T>)_cache.Get(key);
        if (task != null) return task;
        
        var value = populator();
        return 
         (Task<T>)_cache.AddOrGetExisting(key, value, DateTimeOffset.Now.Add(expire)) ?? value;
    }
