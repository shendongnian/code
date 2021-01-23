    public static IDictionary<object, string> ToDictionary(this Type type)
    {
        if (!type.IsEnum) throw new Exception("This is not an enum");
        var names = Enum.GetNames(typeof(T));
        var values = Enum.GetValues(typeof(T));
        return Enumerable.Range(0, names.Length)
                         .Select(index => new
                         {
                             Key = values.GetValue(index),
                             Value = names[index]
                         })
                         .ToDictionary(k => k.Key, k => k.Value);
    }
