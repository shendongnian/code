    void NullPropertyConvertionAction<TSource, TTarget>(TSource source, TTarget target)
    {
        var sourceDictionary = typeof(TSource).GetProperties()
            .ToDictionary(s => 
                s.Name.
                StringComparer.InvariantCultureIgnoreCase
            );
        ParameterExpression p1 = Expression.Parameter(typeof(TSource), "from");
        ParameterExpression p2 = Expression.Parameter(typeof(TTarget), "to");
        var expressionBodies = new List<BinaryExpression>();
        foreach (var member in typeof(TTarget).GetProperties()
            .Where(p=> p.PropertyType.IsGenericType 
            && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
        {
            if (sourceDictionary.ContainsKey(member.Name))
            {
                MemberExpression m1 = Expression.PropertyOrField(p1, sourceDictionary[member.Name].Name);
                MemberExpression m2 = Expression.PropertyOrField(p2, member.Name);
                BinaryExpression body = Expression.Assign(m2, Expression.Convert(m1, member.PropertyType));
                expressionBodies.Add(body);
            }
        }
        BlockExpression block = Expression.Block(expressionBodies.ToArray());   
        LambdaExpression lambda = Expression.Lambda<Action<TSource,TTarget (block, new[] { p1,p2 });
        Action<TSource,TTarget> action = (Action<TSource,TTarget>)lambda.Compile();
        action(source,target);
    }
