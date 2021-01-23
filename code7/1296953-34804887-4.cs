     public static class HtmlBuildersExtended
        {
            public static RouteValueDictionary ConditionalReadonly(
                bool isReadonly,
                object htmlAttributes = null)
            {
                var dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
    
                if (isReadonly)
                    dictionary.Add("readonly", "readonly");
    
                return dictionary;
            }
       }
