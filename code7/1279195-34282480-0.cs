    public static class MyEnumerable
    {
        public static int CustomMethod<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int type)
        {
            return type * source.Sum(selector);
        }
    }
