    public static Type GetPropertyType<T>(Expression<Func<T, object>> expression)
        {
            var info = GetPropertyInformation(expression) as PropertyInfo;
            return info.PropertyType;
        }
        public static MemberInfo GetPropertyInformation<T>(Expression<Func<T, object>> propertyExpression)
        {
            return PropertyInformation(propertyExpression.Body);
        }
        public static PropertyInfo PropertyInformation(Expression propertyExpression)
        {
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }
            if (memberExpr != null)
            {
                var propertyMember = memberExpr.Member as PropertyInfo;
                if (propertyMember != null)
                    return propertyMember;
            }
            return null;
        }
