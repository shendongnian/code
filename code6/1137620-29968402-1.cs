    protected override Expression VisitConditional(ConditionalExpression node)
    {
        DefaultExpression de = node.IfFalse as DefaultExpression;
        if (de != null && de.Type == typeof(void))
        {
            return base.Visit(Expression.IfThenElse(node.Test, node.IfTrue, To));
        }
        return base.VisitConditional(node);
    }
