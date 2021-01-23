    static bool TryGetValue(MemberExpression me, out object value)
    {
    	object source = null;
    	if (me.Expression != null)
    	{
    		if (me.Expression.NodeType == ExpressionType.Constant)
    			source = ((ConstantExpression)me.Expression).Value;
    		else if (me.Expression.NodeType != ExpressionType.MemberAccess
    			|| !TryGetValue((MemberExpression)me.Expression, out source))
    		{
    			value = null;
    			return false;
    		}
    	}
    	if (me.Member is PropertyInfo)
    		value = ((PropertyInfo)me.Member).GetValue(source);
    	else
    		value = ((FieldInfo)me.Member).GetValue(source);
    	return true;
    }
