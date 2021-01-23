    public static MvcHtmlString TextBoxPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? Proper(metadata.PropertyName?? htmlFieldName.Split('.').Last());
    
            if (!String.IsNullOrEmpty(labelText))
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                }
                htmlAttributes.Add("placeholder", modeldata.Description??Proper(metadata.PropertyName?? htmlFieldName.Split('.').Last())); // to get the description value
            }
            return html.TextBoxFor(expression, labelText);
        }
    // this function will convert FullName to Full Name with space
    private static string Proper(string value)
    {
          var newValue = Regex.Replace(value, "([a-z])([A-Z])", "$1 $2");
          return newValue;
    }
