    public static T RandomFirstOptimized<T>(this IEnumerable<T> source, 
                                                 Func<T, bool> predicate, Random rnd)
    {
        var matching = source.Where(predicate);
    
        if (!matching.Any())
            matching.First(); // force the exception;
    
        return matching.ElementAt(rnd.Next(0, matching.Count()));
    }
