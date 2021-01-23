	public static object Evaluate(Expression expr)
	{
		switch (expr.NodeType)
		{
			case ExpressionType.Constant:
				return ((ConstantExpression)expr).Value;
			case ExpressionType.MemberAccess:
				var me = (MemberExpression)expr;
				object target = Evaluate(me.Expression);
				switch (me.Member.MemberType)
				{
					case MemberTypes.Field:
						return ((FieldInfo)me.Member).GetValue(target);
					case MemberTypes.Property:
						return ((PropertyInfo)me.Member).GetValue(target, null);
					default:
						throw new NotSupportedException(me.Member.MemberType.ToString());
				}
			case ExpressionType.New:
				return ((NewExpression)expr).Constructor
					.Invoke(((NewExpression)expr).Arguments.Select(Evaluate).ToArray());
			default:
				throw new NotSupportedException(expr.NodeType.ToString());
		}
	}
