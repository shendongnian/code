    namespace StackOverflowHelp
    {
        public class RedirectHandler : IHttpHandler
        {
            public bool IsReusable
            {
                get { return true; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                Uri uri = context.Request.Url;
    
                if (uri.AbsolutePath == "/WebForm2.aspx.aspx")
                    context.Response.Redirect("http://google.com");
            }
        }
    }
