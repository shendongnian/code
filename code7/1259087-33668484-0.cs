        public static IQueryable<TEntity> WhereNotIn<TEntity, TValue>(
            this IQueryable<TEntity> queryable,
            Expression<Func<TEntity, TValue>> valueSelector,
            IEnumerable<TValue> values)
            where TEntity : class
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");
            if (valueSelector == null)
                throw new ArgumentNullException("valueSelector");
            if (values == null)
                throw new ArgumentNullException("values");
            if (!values.Any())
                return queryable.Where(e => true);
            var parameterExpression = valueSelector.Parameters.Single();
            var equals = from value in values
                         select Expression.NotEqual(valueSelector.Body, Expression.Constant(value, typeof (TValue)));
            var body = equals.Aggregate(Expression.And);
            return queryable.Where(Expression.Lambda<Func<TEntity, bool>>(body, parameterExpression));
        }
    }
