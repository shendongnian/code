    public Expression BuildExprDataRow<T>(Rule r, ParameterExpression param)
    {
    	var right = Expression.Constant(r.TargetValue);
    	var left = Expression.Convert(
            Expression.Property(param, "Item", Expression.Constant(r.MemberName)),
            right.Type);
    	var comparison = (ExpressionType)Enum.Parse(typeof(ExpressionType), r.Operator);
    	return Expression.MakeBinary(comparison, left, right);
    }
