    static object Parse(string typeName, string value)
    {
        var type = Type.GetType(typeName);
        var converter = TypeDescriptor.GetConverter(type);
        if (converter.CanConvertFrom(typeof(string)))
        {
            return converter.ConvertFromInvariantString(value);
        }
        return null;
    }
