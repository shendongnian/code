    public static class LabelExtensions
    {
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, IDictionary<String, Object> htmlAttributes,
            String requiredMarker = "*")
        {
            return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                ExpressionHelper.GetExpressionText(expression), null, htmlAttributes, requiredMarker);
        }
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, Object htmlAttributes, String requiredMarker)
        {
            return LabelFor(html, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), requiredMarker);
        }
        internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, String htmlFieldName,
            String labelText = null, IDictionary<String, Object> htmlAttributes = null, String requiredMarker = null)
        {
            var resolvedLabelText = labelText ??
                                    metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var tag = new TagBuilder("label");
            tag.Attributes.Add("for",
                TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tag.SetInnerText(resolvedLabelText);
            tag.MergeAttributes(htmlAttributes, true);
            if (metadata.IsRequired && !String.IsNullOrWhiteSpace(requiredMarker))
            {
                var requiredSpan = new TagBuilder("span") {InnerHtml = requiredMarker};
                requiredSpan.AddCssClass("required");
                tag.InnerHtml += requiredSpan;
            }
            var result = tag.ToString(TagRenderMode.Normal);
            return new MvcHtmlString(result);
        }
    }
