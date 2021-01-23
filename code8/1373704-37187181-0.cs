    public static IHtmlString StringTemplateFor<TModel, TProperty>(
		this HtmlHelper<TModel> htmlHelper, 
        Expression<Func<TModel, IEnumerable<TProperty>>> expression)
    {
		return new HtmlString(
            attribute.FormatInvariant(((IEnumerable<TProperty>)metadata.Model).ToArray()));
	}
