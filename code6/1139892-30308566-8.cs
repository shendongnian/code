    public T Map<T>(dynamic item) where T : class
    {
        // inline for clarity
        var mappings = new Dictionary<Type,Func<dynamic,object>>
            {
                { typeof(Project), map => new Project(map["project"]["name"]) }
            };
        return (T)mappings[typeof(T)].Invoke(item);
    }
