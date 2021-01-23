    /// <summary> Default side-effect style enumeration </summary>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var element in source)
            action(element);
    }
