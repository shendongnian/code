    public static IDictionary<string, string> ToDictionary(this Type type)
    {
        if (!type.IsEnum)
        {
            throw new InvalidCastException("'enumValue' is not an Enumeration!");
        }
        var names = Enum.GetNames(type);
        var values = Enum.GetValues(type);
        return Enumerable.Range(0, names.Length)
                         .Select(index => new
                         {
                             Key = names[index],
                             Value = ((Enum)values.GetValue(index)).Description()
                         })
                         .ToDictionary(k => k.Key, k => k.Value);
    }
