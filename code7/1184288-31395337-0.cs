    ParameterExpression parameter = Expression.Parameter(typeof(Attendees));
    Expression left = Expression.Equal(Expression.Property(parameter, "Property"), Expression.Constant(constproperty));
    Expression right = Expression.Equal(Expression.Property(parameter, "Value"), Expression.Constant(constValue));
    Expression joined = Expression.And(left, right);
    
    var anyMethod = typeof(Queryable).GetMethods().Where(m => m.Name=="Any" && m.GetParameters().Count() == 2).First().MakeGenericMethod(typeof(Attendees));
    var call = Expression.Call(anyMethod, Expression.Constant(evnt.AttendeesList, typeof(IQueryable<Attendees>)), Expression.Lambda(joined, parameter));
