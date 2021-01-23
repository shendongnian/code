    MethodCallExpression mce = predicate as MethodCallExpression;
    if (mce == null)
    {
        throw new Exception();
    }
    UnaryExpression quote = mce.Arguments[1] as UnaryExpression;
    if (quote == null || quote.NodeType != ExpressionType.Quote)
    {
        throw new Exception();
    }
    Expression<Func<Amazing, bool>> lambda = quote.Operand as Expression<Func<Amazing, bool>>;
    if (lambda == null)
    {
        throw new Exception();
    }
    IQueryable<Amazing> q4 = Amazings().Where(lambda);
