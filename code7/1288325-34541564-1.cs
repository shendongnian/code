    public static class HtmlHelperExtensions {
        
        internal static IHtmlString ToHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode) {
            System.Diagnostics.Debug.Assert(tagBuilder != null);
            return new HtmlString(tagBuilder.ToString(renderMode));
        }
        public static IHtmlString CreateHtml(this HtmlHelper htmlHelper) {
             return CreateSomeInnerHtml();
        }
        public static IHtmlString CreateSomeInnerHtml() {
            var li = new TagBuilder("li");
            var anchor = new TagBuilder("a");
            a.Attributes["href"] = "http://test:8080/${{var}}";
            li.InnerHtml += a;
            return li.ToHtmlString(TagRenderMode.Normal);
        }
    }
