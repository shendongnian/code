    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        public static IQueryable<T> Search<T>(this IQueryable<T> self, string keyword)
        {
            var predicate = False<T>();
            var properties = typeof(T).GetTypeInfo().DeclaredProperties;
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.GetGetMethod().IsVirtual)
                    continue;
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, propertyInfo);
                var propertyAsObject = Expression.Convert(property, typeof(object));
                var nullCheck = Expression.NotEqual(propertyAsObject, Expression.Constant(null, typeof(object)));
                var propertyAsString = Expression.Call(property, "ToString", null, null);
                var keywordExpression = Expression.Constant(keyword);
                var contains = Expression.Call(propertyAsString, "Contains", null, keywordExpression);
                var lambda = Expression.Lambda(Expression.AndAlso(nullCheck, contains), parameter);
                predicate = predicate.Or((Expression<Func<T, bool>>)lambda);
            }
            return self.Where(predicate);
        }
        
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
