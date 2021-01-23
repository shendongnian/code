    string propname = "prop1"; // you can now change this to any valid property name.
    
    var parameterExpresion = Expression.Parameter(typeof(Demo), "d");
    var binaryExpression = Expression.Equal(
        Expression.Property(parameterExpresion, propname),
        Expression.Constant("value"));
    var lambda = Expression.Lambda<Func<Demo, bool>>(binaryExpression, parameterExpresion);
    
    var data = db.Single<Demo>(lambda);
