    public T Map<T>(dynamic item) where T : class
    {
        // inline for clarity
        var mappings = new Dictionary<Type, Func<dynamic, T>>
            {
                { typeof(Project), map => new Project(map["name"]) as T }
            };
        return mappings[typeof(T)].Invoke(item);
    }
