    var throwMethod = typeof(TheClassThrowIsIn)
        .GetMethod("ThrowHelper", BindingFlags.Static)
        .MakeGenericMethod(typeof(int));
    var expr =
        Expression.Condition(
            Expression.Equal(Expression.Constant(0), Expression.Constant(0)),
            Expression.Call(throwMethod, Expression.Constant(new DivideByZeroException())),
            Expression.Constant(1));
