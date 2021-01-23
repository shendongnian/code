    public static Expression<Func<T, bool>> HasPermission<T>(int PermissionID) where T : class
    {
       ParameterExpression pe = Expression.Parameter(typeof(T), "p");
       System.Reflection.PropertyInfo pi = typeof(T).GetProperty("PermissionID");
       MemberExpression me = Expression.MakeMemberAccess(pe, pi);
       ConstantExpression ce = Expression.Constant(PermissionID);
       BinaryExpression be = Expression.Equal(me, ce);
       return Expression.Lambda<Func<T, bool>>(be, pe);
    }
