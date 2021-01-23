	private static void WalkTree(BinaryExpression body, ExpressionType linkingType,
								 ref List<QueryParameter> queryProperties)
	{
		if (body.NodeType != ExpressionType.AndAlso && body.NodeType != ExpressionType.OrElse)
		{
			string propertyName = GetPropertyName(body);
			var propertyValue = GetPropertyValue(body.Right);
			string opr = GetOperator(body.NodeType);
			string link = GetOperator(linkingType);
			queryProperties.Add(new QueryParameter(link, propertyName, propertyValue, opr));
		}
		else
		{
			WalkTree((BinaryExpression)body.Left, body.NodeType, ref queryProperties);
			WalkTree((BinaryExpression)body.Right, body.NodeType, ref queryProperties);
		}
	}
	private static object GetPropertyValue(Expression source)
	{
		var constantExpression = source as ConstantExpression;
		if (constantExpression != null)
			return constantExpression.Value;
		var evalExpr = Expression.Lambda<Func<object>>(Expression.Convert(source, typeof(object)));
		var evalFunc = evalExpr.Compile();
		var value = evalFunc();
		return value;
	}
