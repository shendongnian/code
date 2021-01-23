    public static TEnumeration ToEnumeration<TEnum, TEnumeration>(this TEnum value)
    {
        string name = Enum.GetName(typeof(TEnum), value);
        var field = typeof(TEnumeration).GetField(name);
        return (TEnumeration)field.GetValue(null);
    }
