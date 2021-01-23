    private Expression<Func<T, bool>> Contains<T, V>
     (string property, IQueryable<V> values, T item)
    {
            ParameterExpression pe = Expression.Parameter(item.GetType(), "c");
            Expression columnNameProperty = Expression.Property(pe, property);
            var someValueContain = Expression.Constant(values, values.GetType());
            var convertExpression = Expression.Convert(columnNameProperty, typeof(V));
            Expression expression = 
              Expression.Call
              (
                (
                 ((Expression<Func<bool>>)
                 (() => Queryable.Contains(default(IQueryable<V>), default(V)))
                )
                .Body as MethodCallExpression).Method, 
                someValueContain, 
                convertExpression
              );
    
            return Expression.Lambda<Func<T, bool>>(expression, pe);
    }
