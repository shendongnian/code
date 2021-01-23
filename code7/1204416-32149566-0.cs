    public static class MyHeleprs
    { 
        public static MvcHtmlString MyResource(this HtmlHelper htmlHelper, 
        	string resourceString)
        {
    #if(DEBUG)
            return MvcHtmlString.Create(Url.Resource("~/public/" + resourceString));
    #else
             return MvcHtmlString.Create("<path_to_cdn>/" + resourceString);
    #endif
           
        } 
    } 
