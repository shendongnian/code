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
                (() => Queryable.Contains).Method, 
                someValueContain, 
                convertExpression
              );
    
            return Expression.Lambda<Func<T, bool>>(expression, pe);
    }
