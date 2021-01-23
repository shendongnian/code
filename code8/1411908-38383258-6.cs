    public static class ReflectionExtension
    {
        public static PropertyInfo GetPropertyInfo<T>(this Expression<Func<T, object>> expression)
        {
            var memberExpression = GetMemberExpression(expression);
            return (PropertyInfo)memberExpression.Member;
        }
    
        private static MemberExpression GetMemberExpression<TModel, T>(Expression<Func<TModel, T>> expression)
        {
            MemberExpression memberExpression = null;
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }
    
            if (memberExpression == null)
            {
                throw new ArgumentException("Not a member access", "expression");
            }
    
            return memberExpression;
        }
    }
