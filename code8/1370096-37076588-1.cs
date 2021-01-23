    public static bool HasProperty(this ExpandoObject value, string property)
    {
        bool hasProp = false;
        if (((IDictionary<String, object>)value).ContainsKey(property))
        {
            hasProp = true;
        }
        return hasProp;
    }
    
    public static T Get<T>(this ExpandoObject value, string property)
    {
        return (T)((IDictionary<String, dynamic>)value)[property];
    }
