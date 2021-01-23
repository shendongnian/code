    void DoWork(Type type)
    {
        var props = type.GetProperties().Where(p => p.HasAttribute(MyAttribute)).ToList();
        var tupleFactory = TupleFactory.Create(props.Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType)));
        var param = Expression.Parameter(type, "x");
        var newEx = tupleFactory.MakeNewExpression(props.Select(p => Expression.Property(param, p)));
        var lambda = Expression.Lambda(newEx, param); // <-- type is LambdaExpression, not dynamic
        MyFunction(lambda);
    }
