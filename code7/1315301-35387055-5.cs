    static readonly Expression<Func<DateTime, string>> Date_ToString = date =>
    	DbFunctions.Right("000" + date.Year.ToString(), 4) + "-" +
    	DbFunctions.Right("0" + date.Month.ToString(), 2) + "-" +
    	DbFunctions.Right("0" + date.Day.ToString(), 2) + " " +
    	DbFunctions.Right("0" + date.Hour.ToString(), 2) + ":" +
    	DbFunctions.Right("0" + date.Minute.ToString(), 2) + ":" +
    	DbFunctions.Right("0" + date.Second.ToString(), 2);
    
    static Expression ToDateString(this Expression source)
    {
    	return Date_ToString.ReplaceParameter(source);
    }
    
    static Expression ReplaceParameter(this LambdaExpression expression, Expression target)
    {
    	return new ParameterReplacer { Source = expression.Parameters[0], Target = target }.Visit(expression.Body);
    }
    
    class ParameterReplacer : ExpressionVisitor
    {
    	public ParameterExpression Source;
    	public Expression Target;
    	protected override Expression VisitParameter(ParameterExpression node)
    	{
    		return node == Source ? Target : base.VisitParameter(node);
    	}
    }
