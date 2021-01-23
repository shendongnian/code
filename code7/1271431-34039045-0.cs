    public static class MyQueryableExtensions {
        public static Task<T> FindMessageAsync<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate) {
            if(source == null) {
                throw new ArgumentNullException("source");
            }
            // Or whatever...
            return source.FirstOrDefault(predicate);
        }
    }
