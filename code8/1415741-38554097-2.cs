    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node.Method.DeclaringType == typeof(Enumerable) && node.Arguments[0].Type == typeof(ICollection<DomainPerson>))
        {
            Expression obj = Visit(node.Object);
            IEnumerable<Expression> args = Visit(node.Arguments);
            if (obj != node.Object || args != node.Arguments)
            {
                var generic = typeof(Enumerable).GetMethods()
                                .Where(m => m.Name == node.Method.Name)
                                .Where(m => m.GetParameters().Length == node.Arguments.Count)
                                .Single();
                var constructed = generic.MakeGenericMethod(typeof(DtoFavouriteColour));
                return Expression.Call(obj, constructed, args);
            }
        }
        return node;
    }
