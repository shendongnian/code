    public static class EnumerableExtensions
    {
        public static IEnumerable<T3> CrossJoin<T, T2, T3>(
            this IEnumerable<T> source,
            IEnumerable<T2> other,
            Func<T, T2, T3> resultSelector)
        {
            return source.Join(other, x => true, x => true, resultSelector);
        }
    }
