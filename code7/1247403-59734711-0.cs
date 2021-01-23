protected override Expression VisitMethodCall(MethodCallExpression node)
{
	//Don't overwrite if fetch wasn't the method being called
	if (!node.Method.Name.Equals(nameof(EagerFetchingExtensionMethods.Fetch))
		&& !node.Method.Name.Equals(nameof(EagerFetchingExtensionMethods.FetchMany))
		&& !node.Method.Name.Equals(nameof(EagerFetchingExtensionMethods.ThenFetch))
		&& !node.Method.Name.Equals(nameof(EagerFetchingExtensionMethods.ThenFetchMany)))
	{
		return base.VisitMethodCall(node);
	}
	//Get the first argument to the Fetch call. This would be our IQueryable or an Expression which returns the IQueryable.
	var fetchInput = node.Arguments[0];
	Expression returnExpression;
	switch (fetchInput.NodeType)
	{
		case ExpressionType.Constant:
			//If the input was a constant we need to run it through VisitConstant to get the underlying queryable from NHibernateQueryableProxy if applicable
			returnExpression = VisitConstant((ConstantExpression)fetchInput);
			break;
		default:
			//For everything else just return the input to fetch
			//This is covers cases if we do something like .Where(x).Fetch(x), here fetchInput would be another method call
			returnExpression = fetchInput;
			break;
	}
	return returnExpression;
}
What this does is rewrite the expression before it gets executed and completely removes the `Fetch` calls so we never end up with the Linq internals from trying to call it.
