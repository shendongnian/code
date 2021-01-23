    public sealed class HttpOverrides : IHttpModule
    {
        void IHttpModule.Init(HttpApplication app)
        {
            app.BeginRequest += OnBeginRequest;
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            string forwardedFor = app.Context.Request.Headers["X-Forwarded-For"]?.Split(new char[] { ',' }).FirstOrDefault();
            if (forwardedFor != null)
            {
                app.Context.Request.ServerVariables["REMOTE_ADDR"] = forwardedFor;
                app.Context.Request.ServerVariables["REMOTE_HOST"] = forwardedFor;
            }
            string forwardedProto = app.Context.Request.Headers["X-Forwarded-Proto"];
            if (forwardedProto == "https")
            {
                app.Context.Request.ServerVariables["HTTPS"] = "on";
                app.Context.Request.ServerVariables["SERVER_PORT"] = "443";
                app.Context.Request.ServerVariables["SERVER_PORT_SECURE"] = "1";
            }
        }
        void IHttpModule.Dispose()
        {
        }
    }
