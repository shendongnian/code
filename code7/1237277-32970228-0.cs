    public static IEnumerable<IEnumerable<T>> Bin<T>(this IEnumerable<T> items, int binSize)
    {
        return items.Select((x,i) => new{x,i})
                    .GroupBy(a => a.i / binSize)
                    .Select(grp => grp.Select(a => a.x));
    }
