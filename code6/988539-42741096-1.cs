        public static void IgnoreProperty<T, TR>(this T parameter, Expression<Func<T, TR>> propertyLambda)
        {
            var parameterType = parameter.GetType();
            var propertyName = propertyLambda.GetReturnedPropertyName();
            if (propertyName == null)
            {
                return;
            }
            var jsonPropertyAttribute = parameterType.GetProperty(propertyName).GetCustomAttribute<JsonPropertyAttribute>();
            jsonPropertyAttribute.DefaultValueHandling = DefaultValueHandling.Ignore;
        }
        public static string GetReturnedPropertyName<T, TR>(this Expression<Func<T, TR>> propertyLambda)
        {
            var member = propertyLambda.Body as MemberExpression;
            var memberPropertyInfo = member?.Member as PropertyInfo;
            return memberPropertyInfo?.Name;
        }
