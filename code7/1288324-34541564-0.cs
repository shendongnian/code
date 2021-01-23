    public static class HelperExtensions {
        
        internal static IHtmlString ToHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode) {
            System.Diagnostics.Debug.Assert(tagBuilder != null);
            return new HtmlString(tagBuilder.ToString(renderMode));
        }
        public static IHtmlString CreateHtml(this HtmlHelper htmlHelper) {
            var li = new TagBuilder("li");
            var anchor = new TagBuilder("a");
            anchor.Attributes["href"] = "http://test:8080/${{var}}";
            li.InnerHtml += anchor;
            return li.ToHtmlString(TagRenderMode.Normal);
        }
    }
