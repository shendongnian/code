    public static class CustomHtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, 
            string src, 
            object htmlAttributes)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
