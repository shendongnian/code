    short GameId = Convert.ToInt16(Session["GlobalGameFilter"]);
    Type currentType = e.Query.ElementType;
    
    ParameterExpression typeParameterExpression = Expression.Parameter(currentType);
    ConstantExpression propertyConstantExpression = Expression.Constant(GameId, GameId.GetType());
    BinaryExpression equalityExpression = Expression.Equal(Expression.PropertyOrField(typeParameterExpression, "GameId"), propertyConstantExpression);
    
    Type genericFunc = typeof(Func<,>).MakeGenericType(currentType, typeof(bool));
    var predicateExpression = Expression.Lambda(genericFunc, equalityExpression, typeParameterExpression);
    
    var whereMethods = typeof(System.Linq.Queryable)
    .GetMethods(BindingFlags.Static | BindingFlags.Public)
    .Where(mi => mi.Name == "Where");
    MethodInfo whereMethod = whereMethods.ElementAt(0).MakeGenericMethod(currentType);
    
    
    var result = whereMethod.Invoke(e.Query, new object[] { e.Query, predicateExpression });
    
    e.Query = (IQueryable)result;
