    public static T?[] ConvertNullable<T>(string delimitedValues) where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException();
        }
        if (delimitedValues == string.Empty)
        {
            return new T[0];
        }
        string[] parts = delimitedValues.Split(',');
        T?[] converted = new T?[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i] == string.Empty)
            {
                continue;
            }
            T value;
            if (!Enum.TryParse(parts[i], out value))
            {
                throw new FormatException(parts[i]);
            }
            converted[i] = value;
        }
        return converted;
    }
