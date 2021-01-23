    public Expression<Func<double, double, double>> IThinkThisWorks()
    {
        var paramA = Expression.Parameter(typeof(double), "a");
        var paramB = Expression.Parameter(typeof(double), "b");
        var const0 = Expression.Constant(0.0);
        var test = Expression.Equal(paramA, paramB);
        var division = Expression.Divide(paramA, paramB);
        var ifCheck = Expression.IfThenElse(test, const0, division);
        return Expression.Lambda<Func<double, double, double>>(ifCheck, paramA, paramB);
    }
