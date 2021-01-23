    public static MvcHtmlString ValidateionUseridTooltipFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
    {
        var attributes = new { @class = "tooltip fade top in", role = "tooltip" };
        MvcHtmlString validation = ValidationExtensions.ValidationMessageFor(helper,expression, null, attributes);
       return validation;
       // or if you want to enclose this in the div
       TagBuilder div = new TagBuilder("div");
       div.Attributes.Add(....);
       div.InnerHtml = validation.ToString();
       return validation; 
    }
