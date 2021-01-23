    public static class AppEditors
    {
        public static MvcHtmlString AppTextBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null )
        {
            var member = expression.Body as MemberExpression;
            var placeholder = member.Member
                                    .GetCustomAttributes(typeof(Display), false)
                                    .FirstOrDefault() as Display;
        
            var attributes = (IDictionary<string, object>)newRouteValueDictionary(htmlAttributes) ?? new RouteValueDictionary();
            
            if (placeholder!= null)
            {
                attributes.Add("placeholder", placeholder.Prompt);
                return htmlHelper.TextBoxFor(expression, attributes);
            }
        }
    }
