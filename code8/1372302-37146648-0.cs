    // At this point, orderByExp is c => c.ActionDate
    var orderByDescendingCall = Expression.Call(
    	typeof(Enumerable), "OrderByDescending", new Type[] { childType, orderByExp.Body.Type },
    	propertyGetter, orderByExp
    );
    var firstOrDefaultCall = Expression.Call(
    	typeof(Enumerable), "FirstOrDefault", new Type[] { childType },
    	orderByDescendingCall
    );
    propertyGetter = Expression.Property(firstOrDefaultCall, childProp);
