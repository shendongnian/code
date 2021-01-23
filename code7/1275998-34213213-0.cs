    public static MvcHtmlString BootstrapActionLink(this HtmlHelper htmlHelper, string linkText, string linkUrl, string bootstrapClasses, string glyphClasses)
    {
        TagBuilder anchor = new TagBuilder("a");
        anchor.MergeAttribute("href", linkUrl);
        anchor.AddCssClass(bootstrapClasses);
 
        TagBuilder span = new TagBuilder("span");
        span.AddCssClass(glyphClasses);
        anchor.InnerHtml = linkText + " " + span.ToString();
 
        return MvcHtmlString.Create(anchor.ToString());
    }
