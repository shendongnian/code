    public T GetCookie<T>(string key)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)-1;
        }
        return default(T);
    }
