    public static class DynamicLinqExtensions
    {
        public static IEnumerable<TSource> FilterByUniqueProp<TSource>
                (this IEnumerable<TSource> query, TSource model)
        {
            // Do something accourding to this type
            var type = typeof(TSource);
            return null;
        }
        public static IEnumerable<TSource> FilterByUniqueProp2<TSource>
                (this IEnumerable<object> query, TSource model)
        {
            // We use Cast<>() to conver the IEnumerable<>
            return query.Cast<TSource>().FilterByUniqueProp<TSource>(model);
        }
    }
