    public static Expression<Func<double, double>> GetExpression(string s)
	{
		Expression result = GetExpressionInternal(s);
		return Expression.Lambda<Func<double, double>>(result, Parameter);
	}
