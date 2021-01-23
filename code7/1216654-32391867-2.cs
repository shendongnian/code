    public static class HtmlHelperExtensions
        {
            public static MvcHtmlString PartialWithPrefix(this HtmlHelper html, string partialViewName, object model, string prefix)
            {
                var viewData = new ViewDataDictionary(html.ViewData)
                {
                    TemplateInfo = new TemplateInfo
                    {
                        HtmlFieldPrefix = prefix
                    }
                };
    
                return html.Partial(partialViewName, model, viewData);
            }
        }
