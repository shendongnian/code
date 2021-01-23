    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // here you have access to context.Request and context.Response
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
