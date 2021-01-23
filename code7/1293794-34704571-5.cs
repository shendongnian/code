    var parameter = Expression.Parameter(typeof(User), "source");
    var memberOwnerParameter = Expression.PropertyOrField(source, propertyName); // propertyName is "Id" in your case.
    
    ConstantExpression value = Expression.Constant(14);
    Expression eq = Expression.Equal(memberOwnerParameter, value);
        
    ConstantExpression value2 = Expression.Constant(15);
    Expression eq2 = Expression.NotEqual(memberOwnerParameter, value2);
        
    Expression final = Expression.And(eq, eq2);
