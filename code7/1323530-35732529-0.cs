    public static MvcHtmlString Test<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
    {
        var someCondition = false;
        if (someCondition)
        {
           // Return some domain specific html.
           return new MvcHtmlString("<div></div>");
        }
        else
        {
            var result = expression.Compile();
            TModel model = html.ViewData.Model;
            var value = result(model);
            var r = new MvcHtmlString(value.ToString());
            return r;
        }
    }
