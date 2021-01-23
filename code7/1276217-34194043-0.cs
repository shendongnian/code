    public static Expression<Func<TItem, bool>> PropertyEquals<TItem>(string[] properties, string value)
    {
        MethodInfo startWithMethod = typeof(string).GetMethod("StartsWith", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
        ParameterExpression parameter = Expression.Parameter(typeof(TItem));
        ConstantExpression constant = Expression.Constant(value);
        MemberExpression[] members = new MemberExpression[properties.Length];
        for (int i = 0; i < properties.Length; i++)
            members[i] = Expression.Property(parameter, properties[i]);
        Expression predicate = null;
        foreach (var item in members)
        {
            MethodCallExpression callExp = Expression.Call(item, startWithMethod, constant);
            predicate = predicate == null 
                ? (Expression)callExp
                : Expression.OrElse(predicate, callExp);
        }
        return Expression.Lambda<Func<TItem, bool>>(predicate, parameter);
    }
