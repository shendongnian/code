    public static IEnumerable<Expression> AllJoinCombinations(Expression expression)
    {
    	var combinations = expression.FindJoins()
    		.Select(join => new Tuple<JoinExpression, Expression>[]
    		{
    			Tuple.Create<JoinExpression, Expression>(join, new NestLoopJoinExpresion(join)), 
    			Tuple.Create<JoinExpression, Expression>(join, new MergeJoinExpresion(join)),
			})
			.CartesianProduct();
			
		return combinations.Select(combination => expression.ReplaceAll(combination));
    }
