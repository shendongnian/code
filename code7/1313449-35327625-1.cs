    public static class ExtensionMethods
    {
        public static IEnumerable<TResult> SelectTwo<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TResult> selector)
        {
            return source.Select((item, index) => new {item, index})
                .GroupBy(x => x.index/2)
                .Select(g => g.Select(i => i.item).ToArray())
                .Select(x => selector(x[0], x[1]));
        }
    }
