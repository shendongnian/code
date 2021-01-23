    public static class MyRazorExtensions
    {
        public static MvcHtmlString MyCustomRazorStringRenderer(this HtmlHelper helper, string razorCode)
        {
            // Do things, as described below, to generate HTML
            return new MvcHtmlString(renderedOutput);
        }
    }
