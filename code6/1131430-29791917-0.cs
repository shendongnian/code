    //Use generics for more information!
    public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> expression)
        {
            if (expression is LambdaExpression)
                expression = ((LambdaExpression)expression).Body;
            if (expression is MemberExpression)
            {
                var memberExpression = (MemberExpression)expression;
                if (memberExpression.Expression.NodeType ==
                    ExpressionType.MemberAccess)
                {
                    return GetMemberName(memberExpression.Expression)
                           + "."
                           + memberExpression.Member.Name;
                }
                return memberExpression.Member.Name;
            }
            //Magic part...
            if (typeof(T) == typeof(TValue))
            {
                 return typeof(T).Name;
            }
            if (expression is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)expression;
                if (unaryExpression.NodeType != ExpressionType.Convert)
                    throw new Exception(string.Format(
                        "Cannot interpret member from {0}",
                        expression));
                return GetMemberName(unaryExpression.Operand);
            }
            throw new Exception(string.Format(
                "Could not determine member from {0}",
                expression));
        }
