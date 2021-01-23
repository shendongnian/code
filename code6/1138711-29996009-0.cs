    public static string Format<T>(T item)
    {
        if (item.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<,>)))
        { FormatDictionary((dynamic) item); }
    }
    
    private static FormatDictionary<TKey, TValue>(IDicitonary<TKey, TValue> item)
