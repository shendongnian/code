    public static IDictionary<int, string> GetAllTypes<TEnum>(TEnum special_value) where TEnum : struct
    {
        var enumerationType = typeof(TEnum);
        if (!enumerationType.IsEnum)
            throw new ArgumentException("Enumeration type is expected.");
        int special_value_int = Convert.ToInt32(special_value);
        var dictionary = new SortedDictionary<int, string>(
            new CustomComparer<int>((x, y) =>
            {
                if (x == special_value_int && x != y)
                    return -1;
                var description_x = GetDescription((AllTypes) x);
                var description_y = GetDescription((AllTypes)y);
                return description_x.CompareTo(description_y);
            }));
        foreach (int value in Enum.GetValues(enumerationType))
        {
            var name = GetDescription((AllTypes)value);
            dictionary.Add(value, name);
        }
        return dictionary;
    }
