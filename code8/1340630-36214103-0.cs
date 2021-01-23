        public static Expression<Func<T, bool>> GetExpression<T, U>(string propertyName, U filterValue)
        {
            var parameter = Expression.Parameter(typeof(T));
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(Expression.Property(parameter, propertyName), 
                Expression.Constant(filterValue)), parameter);
            return predicate;
        }
