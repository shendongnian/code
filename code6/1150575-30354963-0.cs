    var names = new string[] { "name1", "name2", "name3" };
    
    var query = ...; // Your query
    
    if (names.Any())
    {
        // Where MyClass is the type of your class
        ParameterExpression par = Expression.Parameter(typeof(MyClass));
        MemberExpression prop = Expression.Property(par, "Name");
        var expression=names
            .Select(v => Expression.Equal(prop, Expression.Constant(v)))
            .Aggregate(Expression.OrElse);
        // Where MyClass is the type of your class
        var lambda = Expression.Lambda<Func<MyClass, bool>>(expression, par);
        query = query.Where(lambda);
    }
