    public static IEnumerable<IEnumerable<T>> Split<T>(this IList<T> list, Predicate<T> match)
    {
        if (list.Count == 0)
            yield break;
        var chunkStart = 0;
        for (int i = 1; i < list.Count; i++)
        {
            if (match(list[i]))
            {
                yield return new ListSegment<T>(list, chunkStart, i - 1);
                chunkStart = i;
            }
        }
        yield return new ListSegment<T>(list, chunkStart, list.Count - 1);
    }
