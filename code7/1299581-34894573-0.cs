    public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
    {
        T someObject = new T();
        Type someObjectType = someObject.GetType();
        
        foreach (KeyValuePair<string, object> item in source)
        {
            someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
        }
        return someObject;
    }
