    public static T RandomFirstOptimized<T>(this IEnumerable<T> source, 
                                            Func<T, bool> predicate, Random rnd)
    {
        var matching = source.Where(predicate);
    
        int matchCount = matching.Count();
        if (matchCount == 0)
            matching.First(); // force the exception;
    
        return matching.ElementAt(rnd.Next(0, matchCount));
    }
