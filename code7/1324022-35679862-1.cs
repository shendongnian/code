    public static class ExpressionExtensions
    {
    	public static Expression<Func<T1, TResult>> FixParam<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> expression, T2 parameterValue)
    	{
    		var parameterToRemove = expression.Parameters.ElementAt(1);
    		var replacer = new ParameterReplacer(parameterToRemove, Expression.Constant(parameterValue, typeof(T2)));
    		return Expression.Lambda<Func<T1, TResult>>(replacer.Visit(expression.Body), expression.Parameters.Where(p => p != parameterToRemove));
    	}
    }
