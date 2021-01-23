    public static IEnumerable<T> ApplyFilter<T>(this IQueryable<T> qry, Func<T, string> field, string likeFilter)
    {
        foreach (var item in qry)
        {
            if (field(item).Contains(likeFilter))
            {
                yield return item;
            }
        }
    }
