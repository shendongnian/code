    public static TSource First<TSource>(this IEnumerable<TSource> source)
    {
        IList<TSource> list = source as IList<TSource>;
        if (list != null)
        {
            if (list.Count > 0)
            {
                return list[0];
            }
        }
        else
        {
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }
        }
    }
