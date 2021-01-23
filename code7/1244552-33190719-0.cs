    private TDestination Map<TSource, TDestination>(TSource source, Dictionary<string, string> mapData)
            where TSource : class
            where TDestination : class, new()
    {
        if (source == null) return null;
        if (mapData == null) mapData = new Dictionary<string, string>();
        TDestination destination = new TDestination();
        PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
        foreach (PropertyInfo property in sourceProperties)
        {
            string destPropertyName = mapData.ContainsKey(property.Name) ? mapData[property.Name] : property.Name;
            PropertyInfo destProperty = typeof(TDestination).GetProperty(destPropertyName);
            if (destProperty == null) continue;
            destProperty.SetValue(destination, property.GetValue(source));
        }
        return destination;
    }
