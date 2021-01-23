    public static MvcHtmlString DisplayForEnumerable<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string templateName, object additionalViewData = null)
    {
        ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        IEnumerable collection = metaData.Model as IEnumerable;
        if (collection == null)
        {
            return helper.DisplayFor(expression, templateName, additionalViewData );
        }
        StringBuilder html = new StringBuilder();
        foreach (var item in collection)
        {
            html.Append(helper.DisplayFor(m => item, templateName, additionalViewData).ToString());
        }
        return MvcHtmlString.Create(html.ToString());
    }
