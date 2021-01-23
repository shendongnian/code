    public static T ParseClientRequest<T>(object data)
    {
        var t = (System.Collections.Generic.Dictionary<string, object>)data;
        T obj = (T)Activator.CreateInstance(typeof(T));
        foreach (var pair in t)
        {
            FieldInfo field = obj.GetType().GetField(pair.Key);
            field.SetValue(obj, Convert.ChangeType(pair.Value, field.FieldType)); //See this line
        }
        return obj;
    }
