    public static List<T> LikeSearch<T>(this List<T> data, string key, string searchString)
    {
        var property = typeof(T).GetProperty(key);
        if (property == null)
            throw new ArgumentException($"'{typeof(T).Name}' does not implement a public get property named '{key}'.");
        return data.Where(d => ((string)property.GetValue(d)).Equals(searchString)).ToList();
    }
