    public static class QueryableExtensions {
       public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, string propertyName, string searchValue)
            {
                var type = typeof (T);
               //this will be the left part of the lambda
                var parameter = Expression.Parameter(type, "s");
                //s.country for example
                var property = Expression.Property(parameter, propertyName);
                //string.Contains method
                var containsMethod = typeof (string).GetMethod("Contains", new[] {typeof (string)});
                //s.country.Contains(<yoursearchvalue>)
                var expression = Expression.Call(property, containsMethod, Expression.Constant(searchValue));
                //s => s.country.Contains(<yoursearchvalue>)
                var lambda = Expression.Lambda<Func<T, bool>>(expression, parameter);
                //filter your queryable with predicate
                return queryable.Where(lambda);
            }
    }
