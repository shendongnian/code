    public static class MyLinq
    {
        public static IEnumerable<TResult> MySelect<TSource,TResult>(this IEnumerable<TSource>, Func<TSource,TResult> selector)
        {
            // implement yourself
        }
        public static TSource MyElementAt<TSource>(this IEnumerable<TSource>, int index)
        {
            // implement yourself
        }
