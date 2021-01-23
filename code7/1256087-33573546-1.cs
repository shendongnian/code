    using System.Web;
    
    namespace HttpHandlers
    {
        public class Handler4 : IHttpHandler
        {
            public bool IsReusable
            {
                get { return true; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                context.Response.Write("Hello World from Handler4.cs");
            }
        }
    }
