    var names = new string[] { "name1", "name2", "name3" };
    // Where MyClass is the type of your class
    ParameterExpression par = Expression.Parameter(typeof(MyClass));
    MemberExpression prop = Expression.Property(par, "Name");
    Expression expression = null;
    foreach (string name in names)
    {
        Expression expression2 = Expression.Equal(prop, Expression.Constant(name));
        if (expression == null)
        {
            expression = expression2;
        }
        else
        {
            expression = Expression.OrElse(expression, expression2);
        }
    }
    var query = ...; // Your query
    if (expression != null)
    {
        // Where MyClass is the type of your class
        var lambda = Expression.Lambda<Func<MyClass, bool>>(expression, par);
        query = query.Where(lambda);
    }
