    public static IHtmlString ActionLink(this HtmlHelper html, IHtmlString innerHtml, string action, string controller, IDictionary<string, object> htmlAttributes)
    {
        var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
        var tag = new TagBuilder("a");
        tag.MergeAttributes(htmlAttributes);
        tag.MergeAttribute("href", urlHelper.Action(action, controller));
        return new HtmlString(tag.ToString(TagRenderMode.Normal));
    }
