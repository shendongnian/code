    private readonly Dictionary<Type, object> allCaches = new Dictionary<Type, object>();
    
    public IDictionary<int, T> GetCache<T>() where T : BaseClass
    {
        object cache;
    
        if (!allCaches.TryGetValue(typeof(T), out cache))
        {
            cache = new Dictionary<int, T>();
            allCaches.Add(typeof(T), cache);
        }
    
        return (IDictionary<int, T>) cache;
    }
