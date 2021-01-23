    public static IEnumerable<T> DuplicateItems<T>(this IEnumerable<T> items, int factor)
    {
        if (items == null) throw new ArgumentNullException("items");
        if (factor <= 0) throw new ArgumentException("factor must be >= 1", "factor");
        if (factor == 1) return items;
        List<T> list = new List<T>();
        using (var enumerator = items.GetEnumerator())
        {
            for (int i = 0; i < factor; i++)
            {
                while (enumerator.MoveNext())
                    list.Add(enumerator.Current);
                enumerator.Reset();
            }
        }
        return list;
    }
