    public static class HtmlExtensions
    {
        public static IHtmlString GetHighlightClass(this HtmlHelper htmlHelper, bool shouldHighlight)
        {
            return shouldHighlight ? MvcHtmlString.Create("highlight") : null;
        }
    }
