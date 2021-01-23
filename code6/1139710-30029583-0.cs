	Type tableType = typeof (incommingtableName); // table type
    string idPropertyName = "ID"; // id proeprty name
    int myId = 42; // value for searching
    // here we are building lambda expression dynamically. It will be like m => m.ID = 42;
    ParameterExpression param = Expression.Parameter(tableType, "m"); 
    MemberExpression idProperty = Expression.PropertyOrField(param, idPropertyName);
    ConstantExpression constValue = Expression.Constant(myId);
    BinaryExpression body = Expression.Equal(idProperty, constValue);
    var lambda = Expression.Lambda(body, param);
	
	// then we would need to get generic method. As SingleOrDefault is generic method, we are searching for it,
	// and then construct it based on tableType parameter
	// in my example i've used CodeFirst context, but it shouldn't matter
	SupplyDepot.DAL.SupplyDepotContext context = new SupplyDepotContext();
    var dbTable = context.Set(tableType);
    // here we are getting SingleOrDefault<T>(Expression) method and making it as SingleOrDefault<tableType>(Expression)
    var genericSingleOrDefaultMethod =
        typeof (Queryable).GetMethods().First(m => m.Name == "SingleOrDefault" && m.GetParameters().Length == 2);
	var specificSingleOrDefault = genericSingleOrDefaultMethod.MakeGenericMethod(tableType);
	// and finally we are exexuting it with constructed lambda
	var result = specificSingleOrDefault.Invoke(null, new object[] { dbTable, lambda });
