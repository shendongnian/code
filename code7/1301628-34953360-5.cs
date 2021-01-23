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
                // For example - To add header only for JS files
                if (HttpContext.Current.Request.Url.ToString().Contains(".js"))
                {
                    HttpContext.Current.Response.Headers.Add("X-FRAME-OPTIONS", "SAMEORIGIN");
                }
            }
        }
    }
