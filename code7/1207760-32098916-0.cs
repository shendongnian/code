    var finalExpression = Expression.Call(
        typeof (Queryable),
        "OrderBy",
        new[] { list.ElementType, propertyToOrder.Type },
        list.Expression,
        Expression.Lambda(propertyToOrder, new [] { argument }));
