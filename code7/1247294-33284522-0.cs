    public static bool IsValid(object value)
    {
        Array array = value as Array;
        return array.Length > 0;
    }
