    var c = Expression.Parameter(typeof(Toto), c);
    var member = Expression.PropertyOrField(c, "tatas");
    var elementType = member.Type.GetInterfaces()
        .Single(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        .GetGenericArguments()[0];
    var memberCount = Expression.Call(typeof(Enumerable), "Count", 
        new [] { elementType }, member);
    var constantValue = Expression.Constant(2);
    var countExpression = Expression.Equal(memberCount, constantValue);
    var lambdaExpression = Expression.Lambda<Func<Toto, bool>>(countExpression, c);
    using (var context = new Context())
    {
        var listResult = context.Totos.Where(lambdaExpression).ToList();
        Console.WriteLine(listResult.Count);
    }
