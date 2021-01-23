    ParameterExpression parOld = exp.Parameters[0];
    ParameterExpression parNew = Expression.Parameter(typeof(Base));
    // Replace the parOld with the parNew
    var body2 = (LambdaExpression)new SimpleExpressionReplacer(parOld, parNew).Visit(exp);
    // Note that we have to rebuild the Expression.Lambda<>
    Expression<Func<Base, bool>> expNew = Expression.Lambda<Func<Base, bool>>(body2.Body, body2.Parameters);
