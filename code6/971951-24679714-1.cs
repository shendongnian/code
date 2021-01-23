        public static string BeginSlidePanel(this HtmlHelper html)
        {
            return BeginHtml();
        }
        public static string ContentSlidePanel(this HtmlHelper html, string htmlString)
        {
            return htmlString;
        }
        public static string EndSlidePanel(this HtmlHelper html)
        {
            return EndHtml();
        }
