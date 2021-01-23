    public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes, bool disabled)
    {
        if (disabled)
        {
            StringBuilder html = new StringBuilder();
            // add a hidden input
            html.Append(htmlHelper.HiddenFor(expression).ToString());
            // Get the display text
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string value = metaData.Model.ToString();
            var displayText = selectList.Where(x => x.Value == value).Select(x => x.Text).FirstOrDefault();
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("readonly");
            div.InnerHtml = displayText;
            html.Append(div.ToString());
            return MvcHtmlString.Create(html.ToString());
        }
        return htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes);
    }
