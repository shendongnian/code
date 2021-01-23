        public static MvcHtmlString CustomDisplayFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object model)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            var propertyName = memberExpression.Member is PropertyInfo ? memberExpression.Member.Name : (string)null;
            var prop = model.GetType().GetProperty(propertyName);
            var customAttributeData = prop.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType.Name == "UIHintAttribute");
            if (customAttributeData != null)
            {
                var templateName = customAttributeData.ConstructorArguments.First().Value as string;
                return DisplayExtensions.DisplayFor<TModel, TValue>(htmlHelper, expression, templateName);
            }
            return DisplayExtensions.DisplayFor<TModel, TValue>(htmlHelper, expression);
        }
