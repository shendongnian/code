    static void SetValue<T>(Dictionary<string, object> target, Expression<Func<T, bool>> predicate)
    {
    	var comparison = predicate.Body as BinaryExpression;
    	Debug.Assert(comparison != null);
    	var member = (comparison.Left.NodeType == ExpressionType.Convert ?
    		((UnaryExpression)comparison.Left).Operand :
    		comparison.Left) as MemberExpression;
    	Debug.Assert(member != null);
    	var value = comparison.Right as ConstantExpression;
    	Debug.Assert(value != null);
    	var attribute = Attribute.GetCustomAttribute(member.Member, typeof(SearchColumnAttribute)) as SearchColumnAttribute;
    	var columnName = attribute?.Name ?? member.Member.Name;
    	var columnValue = value.Value;
    	target[columnName] = columnValue;
    }
