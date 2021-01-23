    public static MvcHtmlString MenuItem(
    this HtmlHelper htmlHelper,
    string text,
    string action,
    string controller,
    IList<HyperlinkDataModel> dropdown
    )
    {
        ...
        foreach (var item in dropdown)
        {
            var dropdownli = new TagBuilder("li");
            dropdownli.InnerHtml = htmlHelper.ActionLink(item.LinkText, item.ActionName,
                item.ControllerName, null, null).ToHtmlString();
            dropdownList.InnerHtml += dropdownli;
        }
