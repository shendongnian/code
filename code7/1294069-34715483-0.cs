    public static HtmlTag ToHtmlTag(this MvcHtmlString html)
        {
            HtmlTag htmlTag = null;
            var doc = new HtmlDocument();
            doc.LoadHtml(html.ToHtmlString());
            var tag = doc.DocumentNode.FirstChild;
            if (tag != null)
            {
                htmlTag = new HtmlTag(tag.Name);
                foreach (var attribute in tag.Attributes)
                {
                    htmlTag.Attr(attribute.Name, attribute.Value);
                }
            }
            return htmlTag;
        }
