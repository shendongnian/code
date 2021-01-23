    Expression<Func<Invoice, bool>> condition = null;
    if (sessionModel.FilterChildren.Any())
    {
    	var parameter = Expression.Parameter(typeof(Invoice), "invoice");
    	var body = sessionModel.FilterChildren
    		.Select(filter => Expression.Equal(
    			Expression.Property(parameter, filter.SysName),
    			Expression.Constant(filter.Value, Type.GetType(filter.Type))))
    		.Aggregate(Expression.AndAlso);
    	condition = Expression.Lambda<Func<Invoice, bool>>(body, parameter);
    }
