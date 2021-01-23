    public static class ExtensionMethods
    {
        public static IEnumerable<TResult> SelectTwo<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TResult> selector)
        {
            bool first_item_got = false;
            TSource first_item = default(TSource);
            foreach (var item in source)
            {
                if (first_item_got)
                {
                    yield return selector(first_item, item);
                }
                else
                {
                    first_item = item;
                }
                first_item_got = !first_item_got;
            }
        }
    }
