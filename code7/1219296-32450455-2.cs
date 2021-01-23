        /// <summary>
        /// Adds "Where(_ => !_.StringProperty.StartsWith("someValue"))" to the query.
        /// </summary>
        static IQueryable<T> AddNotStartsWith<T>(IQueryable<T> query, PropertyInfo propertyInfo, string value)
        {
            var parameter = Expression.Parameter(typeof(T));
            var memberAccess = Expression.MakeMemberAccess(parameter, propertyInfo);
            var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            var methodCall = Expression.Call(memberAccess, startsWithMethod, Expression.Constant(value));
            return query
                .Where(Expression.Lambda<Func<T, bool>>(Expression.Not(methodCall), parameter));
        }
