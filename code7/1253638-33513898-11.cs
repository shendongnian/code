    public static IEnumerable<Expression> AllJoinCombinations(Expression expression)
    {
    	var combinations = expression.FindJoins()
    		.Select(join => new Tuple<Expression, Expression>[]
    		{
    			Tuple.Create<Expression, Expression>(join, new NestLoopJoinExpresion(join)), 
    			Tuple.Create<Expression, Expression>(join, new MergeJoinExpresion(join)),
			})
			.CartesianProduct();
			
		return combinations.Select(combination => expression.ReplaceAll(combination));
    }
