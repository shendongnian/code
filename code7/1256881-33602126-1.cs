    private void Set<T, V>(Expression<Func<T, V>> f, Func<V, V> map, T instance)
    {
        V newvalue = map(f.Compile()(instance));
        ParameterExpression pe = Expression.Parameter(typeof(V));
        Expression.Lambda<Action<T, V>>(
            Expression.Assign(f.Body, pe), 
            f.Parameters[0],
            pe)
        .Compile()(instance, newvalue);
    }
