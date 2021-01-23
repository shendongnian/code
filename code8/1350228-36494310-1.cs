    public static T DoGet<T>(this MemoryCache cache, string key) 
    {
        object value = cache.Get(key);
        if (value == null) {
            return default(T);
        }
        // support for nullables. Do not waste performance with 
        // type conversions if it is not a nullable.
        var underlyingType = Nullable.GetUnderlyingType(t);
        if (underlyingType != null)
        {
            value = Convert.ChangeType(value, underlyingType);
        }
        return (T)value;
    }
