    namespace MyExtensions
    {
        public static class HighPrecendenceExtensions
        {
            public static IEnumerable<TSource> WrapAsEnumerable<TSource>(this IEnumerable<TSource> source)
            {
                return source;
            }
        }
        namespace LowerPrecedenceNamespace
        {
            public static class LowPrecedenceExtensions
            {
                public static IEnumerable<TSource> WrapAsEnumerable<TSource>(this TSource source)
                {
                    return new[] { source };
                }
            }
        }
    }
