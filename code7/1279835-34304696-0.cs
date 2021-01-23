    public static IHtmlString CheckBoxWithLabelFor<TModel>(this HtmlHelper<TModel> helper,
        Expression<Func<TModel, bool>> expression, string labelText, object htmlAttributes)
    {
        IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        // add the "checkBoxWithLabel" class
        if (attributes.ContainsKey("class"))
        {
            attributes["class"] = "checkBoxWithLabel " + attributes["class"];
        }
        else
        {
            attributes.Add("class", "checkBoxWithLabel");
        }
        // build the html
        StringBuilder html = new StringBuilder();
        html.Append(helper.CheckBoxFor(expression, attributes));
        html.Append(helper.LabelFor(expression, labelText, new { @class = "checkBoxLabel" }));
        // suggest also adding the validation message placeholder
        html.Append(helper.ValidationMessageFor(expression));
        return MvcHtmlString.Create(html.ToString());
    }
