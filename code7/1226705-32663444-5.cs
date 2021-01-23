    namespace WebMatrix.WebData
    {
        //other class content omitted for brevity
        public static class WebSecurity
        {
            //Context
            internal static HttpContextBase Context
            {
                get { return new HttpContextWrapper(HttpContext.Current); }
            }
            //Request
            internal static HttpRequestBase Request
            {
                get { return Context.Request; }
            }
            
            //WebSecurity.IsAuthenticated 
            public static bool IsAuthenticated
            {
                get {  return Request.IsAuthenticated; }
            }
        }
    }
