    public static IEnumerable<TOutput> UniquifyNames<TSource, TOutput>(
       this IEnumerable<TSource> source,
       Func<TSource, string> nameSelector,
       Func<TSource, string, TOutput> resultProjection
    ) {
       if (source == null) {
          throw new ArgumentNullException(nameof(source));
       }
       if (nameSelector == null) {
          throw new ArgumentNullException(nameof(nameSelector));
       }
       if (resultProjection == null) {
          throw new ArgumentNullException(nameof(resultProjection));
       }
       return UniquifyNamesImpl(source, nameSelector, resultProjection);
    }
