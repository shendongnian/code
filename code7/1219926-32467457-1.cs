    public static MvcHtmlString TextBoxFor<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        IDictionary<string, object> htmlAttributes);
    
    public static MvcHtmlString TextBoxFor<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        object htmlAttributes);
