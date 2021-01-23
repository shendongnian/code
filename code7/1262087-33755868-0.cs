    public static int GetEnumIntValue<T>(T value)
        where T : struct
    {
        Type genericType = typeof(T);
        Debug.Assert(genericType.IsEnum);
        Enum enumValue = Enum.Parse(typeof(T), value.ToString()) as Enum;
        return Convert.ToInt32(enumValue);
    }
