    public static Expression<Func<T, bool>> DynamicWhereExp(string criteria1, string criteria2, string criteria3, string criteria4)
    {
        ParameterExpression Param = Expression.Parameter(typeof(T));
        Expression exp1 = WhereExp1(criteria1, criteria2, Param);
        Expression exp2 = WhereExp1(criteria3, criteria4, Param);
        var body = Expression.And(exp1, exp2);
           
        return Expression.Lambda<Func<T, bool>>(body, Param);
    }
    private static Expression WhereExp1(string field, string type, ParameterExpression param) 
    {
        Expression aLeft = Expression.Property(param, typeof(T).GetProperty(field));
        Expression aRight = Expression.Constant(type);
        Expression typeCheck = Expression.Equal(aLeft, aRight);
        return typeCheck;   
    }
