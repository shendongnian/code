    var argParam = Expression.Parameter(typeof(AutoTrim), "s");
    var expFunc = Expression.Lambda<Func<AutoTrim, bool>>(
            Expression.AndAlso(
                Expression.AndAlso(
                    Expression.Equal(
                        Expression.Property(Expression.Property(Expression.Property(argParam, "AutoModelParent"), "AutoYearMakeParent"), "Year"), 
                        Expression.Constant(year.Value)),
                    Expression.Equal(
                        Expression.Property(Expression.Property(Expression.Property(argParam, "AutoModelParent"), "AutoYearMakeParent"), "Make"),
                        Expression.Constant(make))
                ),
                Expression.Equal(
                    Expression.Property(Expression.Property(argParam, "AutoModelParent"), "Model"), 
                    Expression.Constant(model))
            ),
            argParam
        ).Compile();
