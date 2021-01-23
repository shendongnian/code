    static string SomeFunction<T>(string format, T instance)
    {
        var propertyInfos = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(p => p.Name);
        return Regex.Replace(@"\{(\w+)\}", 
            m => propertyInfos.HasKey(m.Groups[1].Value) 
                     ? propertyInfos[m.Groups[1].Value].GetValue(instance, null) 
                     : m.Value;
    }
