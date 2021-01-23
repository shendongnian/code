    public class RemoveHttpHeadersModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            Guard.ArgumentNotNull(context, "context");
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }
        public void Dispose() { }
        void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application != null)
            {
                HttpResponse response = application.Response;
                response.Headers.Remove("Server");
                response.Headers.Remove("X-Powered-By");
            }
        }
    }
