    static class TimeSpanExtensions
    {
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> enumerable,
                                                 Func<TSource,TimeSpan?> func )
        {
            return enumerable.Aggregate(TimeSpan.Zero, (total, it) =>
                                                        total+=(func(it)??TimeSpan.Zero);
        }
    }
