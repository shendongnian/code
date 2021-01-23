    namespace MyCustomSystem.Web.Helpers
    {
        public static class CustomHelpers
        {
            public static MvcHtmlString GroupedActionButtons(this HtmlHelper helper, string controller, long id)
            {
                var stringBuilder = new StringBuilder();
    
                //Do your logic here.
    
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
        }
    }
