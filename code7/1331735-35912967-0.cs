    public static void GetMyGenericClassOrNull<T>(T? value) where T : struct
    {
        if (value != null)
        {
        }
    }
    public static void GetMyGenericClassOrNull<T>(T value)
    {
        if (value != null)
        {
        }
    }
