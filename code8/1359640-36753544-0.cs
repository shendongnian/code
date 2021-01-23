    if (m.Expression != null && m.Expression.NodeType == ExpressionType.Constant)
    {
        var source = ((ConstantExpression)m.Expression).Value;
        var value = m.Member is PropertyInfo ? 
            ((PropertyInfo)m.Member).GetValue(source) :
            ((FieldInfo)m.Member).GetValue(source);
    }
