    private static IEnumerable recent;
    public static void Blah<T>(this IList<T> ra)
    {
        recent = ra;
        ...
    }
