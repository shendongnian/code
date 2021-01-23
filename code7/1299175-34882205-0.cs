    public static MvcHtmlString SpanInSpan<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression,
                string dataOffset = null,
                IDictionary<string, object> htmlAttributes = (IDictionary<string, object>)null)
            {
                var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
                var spanContent = metadata.Model.ToString();
    
                var tagBuilder = new TagBuilder("span");
                tagBuilder.MergeAttributes(htmlAttributes);
                tagBuilder.MergeAttribute("data-text", "true");
                tagBuilder.InnerHtml = spanContent;
    
                var outerTagBuilder = new TagBuilder("span");
                outerTagBuilder.MergeAttributes(htmlAttributes);
                outerTagBuilder.MergeAttribute("data-offset-key", dataOffset);
                outerTagBuilder.InnerHtml = tagBuilder.ToString(TagRenderMode.Normal);
    
                return MvcHtmlString.Create(outerTagBuilder.ToString(TagRenderMode.Normal));
            }
