    public static IEnumerable<object> GetValues<T>(IEnumerable<T> items, string propertyName)
    {
        Type type = typeof(T);
        var prop = type.GetProperty(propertyName);
        foreach (var item in items)
            yield return prop.GetValue(item, null);
    }
