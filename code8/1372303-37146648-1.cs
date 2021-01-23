    // At this point, orderByExp is c => c.ActionDate
    var orderByDescendingCall = Expression.Call(
    	typeof(Enumerable), "OrderByDescending", new Type[] { childType, orderByExp.Body.Type },
    	propertyGetter, orderByExp
    );
    Expression propertySelector = propertyAccess;
    // If value type property and not nullable, convert it to nullable
    if (propertySelector.Type.IsValueType && Nullable.GetUnderlyingType(propertySelector.Type) == null)
    	propertySelector = Expression.Convert(propertySelector, typeof(Nullable<>).MakeGenericType(propertySelector.Type));
    var selectCall = Expression.Call(
    	typeof(Enumerable), "Select", new Type[] { childType, propertySelector.Type },
    	orderByDescendingCall, Expression.Lambda(propertySelector, childInParam)
    );
    propertyGetter = Expression.Call(
    	typeof(Enumerable), "FirstOrDefault", new Type[] { propertySelector.Type },
    	selectCall
    );
