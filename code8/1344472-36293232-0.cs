    public static T Convert<T>(this object input)
    {
        if (typeof (T) == input.GetType())
            return (T) input;
        var stringValue = input.ToString();
        var converter = TypeDescriptor.GetConverter(typeof(T));
        if (converter.CanConvertFrom(typeof(string)))
        {
            return (T)converter.ConvertFrom(stringValue);
        }
        return default(T);
    }
