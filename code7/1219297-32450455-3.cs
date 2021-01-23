        static IQueryable<T> AddComparisonExpression<T>(IQueryable<T> query, PropertyInfo propertyInfo, Func<Expression, Expression> getComparisonExpression)
        {
            var parameter = Expression.Parameter(typeof(T));
            var memberAccess = Expression.MakeMemberAccess(parameter, propertyInfo);
            return query
                .Where(Expression.Lambda<Func<T, bool>>(getComparisonExpression(memberAccess), parameter));
        }
        /// <summary>
        /// Adds "Where(_ => !_.StringProperty.StartsWith("someValue"))" to the query.
        /// </summary>
        static IQueryable<T> AddNotStartsWith<T>(IQueryable<T> query, PropertyInfo propertyInfo, string value)
        {
            return AddComparisonExpression(query, propertyInfo, memberAccess =>
            {
                var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                var methodCall = Expression.Call(memberAccess, startsWithMethod, Expression.Constant(value));
                return Expression.Not(methodCall);
            });
        }
        /// <summary>
        /// Adds "Where(_ => _.StringProperty.Substring(startIndex, length) == value)" to the query.
        /// </summary>
        static IQueryable<T> AddSubstringEquals<T>(IQueryable<T> query, PropertyInfo propertyInfo, int startIndex, int length, string value)
        {
            return AddComparisonExpression(query, propertyInfo, memberAccess =>
            {
                var substringMethod = typeof(string).GetMethod("Substring", new[] { typeof(int), typeof(int) });
                var methodCall = Expression.Call(memberAccess, substringMethod, Expression.Constant(startIndex), Expression.Constant(length));
                return Expression.Equal(methodCall, Expression.Constant(value));
            });
        }
