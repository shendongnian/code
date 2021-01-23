    public static class ParallelExtensions
    {
        public static void ForEachParallel<TSource>(this IEnumerable<TSource> source, Action<TSource> body)
        {
           if (source == null) 
           {
              throw new ArgumentNullException("source");
           }
            Parallel
                .ForEach(source, body);
        }
    }
