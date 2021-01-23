    public static class HtmlPostExtensions
    {
        public static IHtmlString Post(this HtmlHelper helper, string postContent)
        {
            string postStr = postContent;
            if (postStr.Length > 200)
            {
                   postStr = postStr.Substring(0, 200);    
            }
            return MvcHtmlString.Create(postStr);
        }
    }
