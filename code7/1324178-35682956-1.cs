    var parentParam = parent.Parameters.Single();
    var propExpression = Expression.Property(parentParam, propName);
    var mergeVisitor = new ReplaceVisitor(nav.Parameters.Single(), propExpression);
    var newNavBody = mergeVisitor.Visit(nav.Body);
    var visitor = new UpdateExpressionVisitor(propName, newNavBody);
    return (Expression<Func<T, TMap>>)visitor.Visit(parent);
