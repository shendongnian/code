    public static IEnumerable<T> TakeFirstAndLast<T>(this IEnumerable<T> source, int count)
    {
        var first = new List<T>();
        var last = new LinkedList<T>();
        foreach (var item in source)
        {
            if (first.Count < count)
                first.Add(item);
            if (last.Count >= count)
                last.RemoveFirst();
            last.AddLast(item);
        }
        return first.Concat(last);
    }
