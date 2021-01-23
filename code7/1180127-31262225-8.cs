    public static class TestExtension
    {
        public static String nameof<T, TT>(this T obj, Expression<Func<T, TT>> propertyAccessor)
        {
            if (propertyAccessor.Body.NodeType == ExpressionType.MemberAccess)
            {
    			var memberExpression = propertyAccessor.Body as MemberExpression;
    			if (memberExpression == null)
    				return null;
                return memberExpression.Member.Name;
            }
            return null;
        }
    }
