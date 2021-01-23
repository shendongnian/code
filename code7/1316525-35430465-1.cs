	public static MvcHtmlString MyExtension<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
	{
		helper.ViewContext.ViewData["someValue"] = true;
		return helper.EditorFor(expression, "_MyTemplate");
	}
