    public static void ReplaceAll<T>(this IList<T> list, T value)
    {
        // TODO: Validation
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = value;
        }
    }
