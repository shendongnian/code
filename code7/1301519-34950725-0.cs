    public static void AddIfNotNull<T>(this List<T> list, T? value)
        where T : struct
    {
        if (value.HasValue)
        {
            list.Add(value.Value);
        }
    }
