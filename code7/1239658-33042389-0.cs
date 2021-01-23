    public static void VerifyMemberEqualsValueAfterSetting<TValue>(
        Expression<Func<TValue>> memberExpression,
        TValue value)
    {
        MemberExpression member = (MemberExpression) memberExpression.Body;
        ParameterExpression parameter = Expression.Parameter(typeof (TValue));
        BinaryExpression assignExpresison = Expression.Assign(member, parameter);
    
        Expression.Lambda(assignExpresison, parameter).Compile().DynamicInvoke(value);
    
        TValue after =Expression.Lambda(member, null).Compile().DynamicInvoke();
        VerifyEqual(value,after);
    }
