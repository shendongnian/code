    public static Expression<Func<T2, bool>> SubPredicate<T1, T2>( Expression<Func<T1, bool>> predicate, Expression<Func<T2, T1>> selector )
    {
        var parms = selector.Parameters;
        var a = Expression.Invoke( selector, parms );
        var invocation = Expression.Invoke( predicate, a );
        return ( Expression<Func<T2, bool>> )Expression.Lambda( invocation, parms );
    }
