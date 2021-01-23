    /// <summary>
    /// Split a source IEnumerable into smaller (more manageable) lists.
    /// </summary>
    public static IEnumerable<IList<TSource>> 
        SplitIntoChunks<TSource>(this IEnumerable<TSource> source, int chunkSize)
    {
        long i = 1;
        var list = new List<TSource>();
        foreach (var t in source)
        {
            list.Add(t);
            if (i++ % chunkSize == 0)
            {
                yield return list;
                list = new List<TSource>();
            }
        }
        if (list.Count > 0)
            yield return list;
    }
