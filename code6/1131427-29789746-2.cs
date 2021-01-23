    if (expression is MemberExpression)
    {
        // As-is
    }
    // New condition
    if (expression is ParameterExpression)
    {
        return expression.Type.Name;
    }
