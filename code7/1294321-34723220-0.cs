    public static IEnumerable<T2> ToDtoList<T, T2>(this IQueryable<T> source, Func<T, T2> map)
    {
        var result = source.AsEnumerable()  // to avoid projecting the map into the query
                           .Select(s => map(s));
    
        return result;
    }
