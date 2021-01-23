    public static Type GetPropertyType<T>(Expression<Func<T, object>> expression)
    {
        var body = expression.Body;
        MemberInfo mi = null;
        if (body is UnaryExpression)
        {
            var unaryExpression = body as UnaryExpression;
            if (unaryExpression.Operand is MemberExpression)
                mi = (unaryExpression.Operand as MemberExpression).Member;
        }
        else if (body is MemberExpression)
        {
            mi = (body as MemberExpression).Member;
        }
        
        if(mi is PropertyInfo)
        {
            return (mi as PropertyInfo).PropertyType;
        }
        return null;
    }
