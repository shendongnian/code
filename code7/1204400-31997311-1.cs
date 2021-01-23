    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> list, ulong n)
    {
        ulong i = 0;
        foreach(var item in list)
        {
            if (i++ < n) continue;
            yield return item;
        }
    }
