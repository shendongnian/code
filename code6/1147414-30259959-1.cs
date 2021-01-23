    public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        /* do null checks */
        var result = default(TSource);
        long tally = 0;
        for(var item in source)
            if(predicate(item))
            {
                result = item;
                checked{++tally;}
            }
        switch(tally)
        {
            case 0:
                throw new InvalidOperationException("no matching items");
            case 1:
                return result;
            default:
                throw new InvalidOperationException("too many matching items");
        }
    }
