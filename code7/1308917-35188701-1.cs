    public static class LinqExtensions
    {
        public static IEnumerable<TResult> SelectWithPreviousResult<TSource, TResult>(
            this IEnumerable<TSource> items,
            TResult defaultResult,
            Func<TSource, TResult, TResult> func)
        {
            var previousResult = defaultResult;
            foreach (var item in items)
            {
                var result = func(item, previousResult);
                previousResult = result;
                yield return result;
            }
        }
    }
