    public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
    {
        var memberExpression = expression.Body as MemberExpression;
    
        var attr = memberExpression.Member.GetCustomAttribute(typeof (InputAttribute)) as InputAttribute;
        var result = htmlHelper.TextBoxFor(expression, htmlAttributes);
        if (attr != null)
        {
            var resultStr = result.ToString();
            var match = Regex.Match(resultStr, "name=\\\"\\w+\\\"");
            return new MvcHtmlString(resultStr.Replace(match.Value, "name=\"" + attr.Name + "\""));
        }
    
        return result;
    }
