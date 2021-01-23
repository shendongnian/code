    public static List<T> LikeSearch<T>(this List<T> data, string key, string searchString)
    {
        var property = typeof(T).GetProperty(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
        if (property == null)
            throw new ArgumentException($"'{typeof(T).Name}' does not implement a public get property named '{key}'.");
        //Equals
        return data.Where(d => property.GetValue(d).Equals(searchString)).ToList();
        //Contains:
        return data.Where(d => ((string)property.GetValue(d)).Contains(searchString)).ToList();
    }
