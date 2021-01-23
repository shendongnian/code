    namespace MvcApplication1.Modules
    {
        public class CustomOriginHeader : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.PreSendRequestHeaders += OnPreSendRequestHeaders;
            }
    
            public void Dispose() { }
    
            void OnPreSendRequestHeaders(object sender, EventArgs e)
            {
                 HttpContext.Current.Response.Headers.Add("X-FRAME-OPTIONS", "SAMEORIGIN");
            }
        }
    }
