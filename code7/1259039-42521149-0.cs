    public static IHtmlContent GetContent(this IHtmlHelper helper)
    {
        var content = new HtmlContentBuilder()
                         .AppendHtml("<ol class='content-body'><li>")
                         .AppendHtml(helper.ActionLink("Home", "Index", "Home"))
                         .AppendHtml("</li>");
        if(SomeCondition())
        {
            content.AppendHtml(@"<div>
                Note `HtmlContentBuilder.AppendHtml()` is Mutable
                as well as Fluent/Chainable.
            </div>");
        }
        return content;
    }
