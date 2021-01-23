    public static IDictionary<int, string> GetAllTypes<TEnum>(TEnum special_value) where TEnum : struct
    {
        var enumerationType = typeof(TEnum);
        if (!enumerationType.IsEnum)
            throw new ArgumentException("Enumeration type is expected.");
        var dictionary = new SortedDictionary<int, string>(
            new SpecialValueComparer<int>(Convert.ToInt32(special_value)));
        foreach (int value in Enum.GetValues(enumerationType))
        {
            var name = GetDescription((AllTypes)value);
            dictionary.Add(value, name);
        }
        return dictionary;
    }
