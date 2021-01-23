    public Tuple<Expression, ParameterExpression> BuildExpression<T>(string propertyName, Enums.Operator ruleOperator, ParameterExpression target, List<object> values)
    {
    	var property = propertyName.Split('.').Aggregate((Expression)target, Expression.PropertyOrField);
    	var propertyValue = Expression.Variable(property.Type, "propertyValue");
    	var array = Expression.Variable(typeof(object[]), "array");
    	var length = Expression.Variable(typeof(int), "length");
    	var index = Expression.Variable(typeof(int), "index");
    	var value = Expression.Variable(typeof(object), "value");
    	var result = Expression.Variable(typeof(bool), "result");
    	var endLoop = Expression.Label("endLoop");
    	bool success = ruleOperator != Enums.Operator.NotFoundIn;
    	Expression body = Expression.Block
    	(
    		new ParameterExpression[] { propertyValue, array, length, index, result },
    		Expression.Assign(propertyValue, property),
    		Expression.Assign(array, Expression.Call(Expression.Constant(values), "ToArray", Type.EmptyTypes)),
    		Expression.Assign(length, Expression.ArrayLength(array)),
    		Expression.Assign(index, Expression.Constant(0)),
    		Expression.Assign(result, Expression.Constant(!success)),
    		Expression.Loop
    		(
    			Expression.IfThenElse
    			(
    				Expression.LessThan(index, length),
    				Expression.Block
    				(
    					Expression.IfThen
    					(
    						Expression.Equal(propertyValue, Expression.Convert(Expression.ArrayIndex(array, index), property.Type)),
    						Expression.Block
    						(
    							Expression.Assign(result, Expression.Constant(success)),
    							Expression.Break(endLoop)
    						)
    					),
    					Expression.PostIncrementAssign(index)
    				),
    				Expression.Break(endLoop)
    			),
    			endLoop
    		),
    		result
    	);
    	return Tuple.Create(body, target);
    }
