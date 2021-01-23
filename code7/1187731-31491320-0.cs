    public static MvcHtmlString TextBoxPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
    
            if (!String.IsNullOrEmpty(labelText))
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                }
                htmlAttributes.Add("placeholder", modeldata.Description); // to get the description value
            }
            return html.TextBoxFor(expression, labelText);
        }
