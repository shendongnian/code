        public static IQueryable<Person> WhereEven(this IQueryable<Person> source, Expression<Func<Person, int>> property)
        {
            var expression = Expression.Equal(
                Expression.Modulo(
                    property.Body,
                    Expression.Constant(2)),
                Expression.Constant(0));
            var methodCallExpression = Expression.Call(typeof (Queryable),
                "where",
                new Type[] {source.ElementType},
                source.Expression,
                Expression.Lambda<Func<Person, bool>>(expression, property.Parameters));
            return source.Provider.CreateQuery<Person>(methodCallExpression);
        }
