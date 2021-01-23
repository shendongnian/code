    private static Dictionary<Type, PropertyInfo[]> TypeProperties
        = new Dictionary<Type, PropertyInfo[]>();
    public IEnumerable<PropertyInfo> GetTypeProperties<T>()
    {
        Type type = typeof(T);
        PropertyInfo[] properties;
        if (!TypeProperties.TryGetValue(type, out properties))
            TypeProperties.Add(type, properties = type.GetProperties());
        return properties;
    }
    /* Fixed excerpt from your code */
    var properties = GetTypeProperties<T>();
    foreach (var hdr in header)
    {
        var property = properties.FirstOrDefault(p => p.PropertyName == hdr);
        if (property != null)
        {
            var value = property.GetValue(item.value, null);
            if (value==null) //Doesn't this also mess the order?
                continue;
            d.elements.Add(value.ToString());
        }
    }
    table.data.Add(d);
