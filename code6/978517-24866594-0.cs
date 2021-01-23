        public static IHtmlString DictionaryLabelFor<TModel, TValue>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, string text = null, string prefix = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var displayName = metadata.DisplayName;
            if (string.IsNullOrWhiteSpace(text))
            {
                // Your code to get the label via reflection
                // of the object
                string labelText = ""; 
                return html.Label(prefix + metadata.PropertyName, labelText);
            }
            else
            {
                return html.Label(prefix + metadata.PropertyName, text);
            }
        }
