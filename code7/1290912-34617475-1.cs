    public T GetCachedData<T>(string key)
    {
        try
        {
            if (cache.Contains(key))
                return (T) cache[key];
            return default(T);
        }
        catch(InvalidCastException ex)
        {
            // We can't return null because T can be value type
            // then returns default value for T. For classes it will be null.
            return default(T);
        }
    }
