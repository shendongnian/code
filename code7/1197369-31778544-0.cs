    public static object ConvertFromString(string typeName, string value)
    {
        Type type = Type.GetType(typeName, true);
        TypeConverter converter = TypeDescriptor.GetConverter(type);
        return converter.ConvertFromString(value);
    }
