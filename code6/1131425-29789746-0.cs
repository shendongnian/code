    if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
    {
        return GetMemberName(memberExpression.Expression)
            + "." 
            + memberExpression.Member.Name;
    }
    // New condition
    if (memberExpression.Expression.NodeType == ExpressionType.Constant)
    {
        return memberExpression.Type.Name;
    }
