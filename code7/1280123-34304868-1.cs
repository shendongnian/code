    static class MemberExpressionHelper
    {
        public static TProperty GetPropertyValue<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> expression)
        {
            // case with `UnaryExpression` is omitted for simplicity
            var memberExpression = (MemberExpression)expression.Body;
            var propertyInfo = (PropertyInfo)memberExpression.Member;
            return (TProperty)propertyInfo.GetValue(model);
        }
    }
