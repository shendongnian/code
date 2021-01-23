    public static class CustomHtmlExtensions
    {
        public static MvcHtmlString CustomDisplayFor<TModel, TResult>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> expression)
        {
            ExpressionType type = expression.Body.NodeType;
            if (type == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)expression.Body;
                PropertyInfo pi = memberExpression.Member as PropertyInfo;
                var attributes = pi.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    if (attribute is VisibilityAttribute)
                    {
                        VisibilityAttribute vi = attribute as VisibilityAttribute;
                        if (vi.Status)
                        {
                            var metadata = ModelMetadata.FromLambdaExpression<TModel, TResult>(expression, html.ViewData);
                            return MvcHtmlString.Create(metadata.SimpleDisplayText);
                        }
                    }
                }
            }
            return MvcHtmlString.Create("");
        }
    }
