    Expression AccessMember(Expression obj, string propertyName)
    {
        string[] parts = propertyName.Split(new char[] { '.' }, 2);
        Expression member = Expression.PropertyOrField(obj, parts[0]);
        if (parts.Length > 1)
            member = AccessMember(member, parts[1]);
        return Expression.Condition(Expression.Equal(obj, Expression.Constant(null)),
            Expression.Constant(null, member.Type), member);
    }
