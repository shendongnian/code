    public static class StringExtensions
    {
        public static string MethodName<T>(Expression<Action<T>> action)
        {
            return ReflectionExtensions.GetMethodInfo(action).Name;
        }
        public static string PropertyName<T, TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            return PropertyNameInternal(propertyExpression);
        }
        public static string PropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return PropertyNameInternal(propertyExpression);
        }
        private static string PropertyNameInternal(LambdaExpression propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(@"propertyExpression");
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var ubody = (UnaryExpression)propertyExpression.Body;
                memberExpression = ubody.Operand as MemberExpression;
            }
            if (memberExpression == null)
                throw new ArgumentException(@"The expression is not a member access expression.", @"propertyExpression");
            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException(@"The member access expression does not access a property.", @"propertyExpression");
            return memberExpression.Member.Name;
        }
    }
