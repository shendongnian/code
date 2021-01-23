    public static T? ParseEnum<T>(string input)
        where T : struct 
    {
        int value;
        var isInt = int.TryParse(input, out value);
        return (T?)Enum.GetValues(typeof(T)).OfType<object>()
                       .FirstOrDefault(v => v.ToString() == typeof(T).Name + input
                                        || (isInt & (int)v == value));
    }
