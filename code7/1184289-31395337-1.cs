    ParameterExpression parameter = Expression.Parameter(typeof(Attendees));
    Expression left = Expression.Equal(Expression.Property(parameter, "Property"), Expression.Constant(constproperty));
    
    var objType = constValue == null ? typeof(object) : constValue.GetType();
    var convertLeft = Expression.Convert(Expression.Property(parameter, "Value"), objType);
    var convertRight = Expression.Convert(Expression.Constant(constValue), objType);
    Expression right = Expression.Equal(convertLeft, convertRight);
    Expression joined = Expression.And(left, right);
    
    var anyMethod = typeof(Queryable).GetMethods().Where(m => m.Name=="Any" && m.GetParameters().Count() == 2).First().MakeGenericMethod(typeof(Attendees));
    var call = Expression.Call(anyMethod, Expression.Constant(evnt.AttendeesList, typeof(IQueryable<Attendees>)), Expression.Lambda(joined, parameter));
