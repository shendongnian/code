    public static double AllEqual<TSource>(this IEnumerable<TSource> list, Func<TSource, double> selector)
    {
        // use IList<T> interface to quickly check the size of the
        // list if this interface is available. Use ToArray otherwise.
        var ilist = list as IList<TSource> ?? list.ToArray();
        if (ilist.Count == 0) return 0.0;
        list.Select(selector).Average();
    }
    public static double AllEqual<TSource>(this IEnumerable<TSource> list, Func<TSource, int> selector)
    {
        // use IList<T> interface to quickly check the size of the
        // list if this interface is available. Use ToArray otherwise.
        var ilist = list as IList<TSource> ?? list.ToArray();
        if (ilist.Count == 0) return 0.0;
        list.Select(selector).Average();
    }
    public static TReturn AllEqual<TSource, TReturn>(this IEnumerable<TSource> list, Func<TSource, TReturn> selector)
    {
        // put 2 distinct values into an array
        var distinctItems.Select(selector).Distinct().Take(2).ToArray();
        if (distinct.Length == 1) return distinct[0];
        default(TReturn);
    }
