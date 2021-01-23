    public sealed class NoRemoteHostLookup : IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += ContextOnBeginRequest;
        }
        private void ContextOnBeginRequest(object sender, EventArgs eventArgs)
        {
            var request = HttpContext.Current?.Request;
            if (request != null)
                request.ServerVariables["REMOTE_HOST"] = request.ServerVariables["REMOTE_ADDR"];
        }
    }
