    protected override Expression VisitMember(MemberExpression m)
    {
        object value;
        if (TryGetValue(m, out value))
        {
            // Use the value
        }
    
        return m;
    }
