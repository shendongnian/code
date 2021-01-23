    private static Dictionary<Type, PropertyInfo[]> getPropertiesCache = new Dictionary<Type, PropertyInfo[]>();
            
    public static string GetColumnNames<T>(string prefix)
    {
        var columns = GetProperties(typeof(T)).OrderBy(i => i.Name).Select(i => $"[{prefix}].[{i.Name}]");
    
        return string.Join(", ", columns);
    }
    
    public static IEnumerable<PropertyInfo> GetProperties(Type type)
    {
        if (getPropertiesCache.ContainsKey(type))
            return getPropertiesCache[type].AsEnumerable();
    
        var properties = type
            .GetTypeInfo()
            .DeclaredProperties;
    
        getPropertiesCache.Add(type, properties.ToArray());
    
        return getPropertiesCache[type].AsEnumerable();
    }
