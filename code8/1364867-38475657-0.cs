    public class CustomAuthenticationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
        }
        public void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            if (!SecuirtyHelper.Authenticate(application.Context))
            {
                application.Context.Response.Status = "01 Unauthorized";
                application.Context.Response.StatusCode = 401;
                application.Context.Response.AddHeader("WWW-Authenticate", "Basic realm=localhost");
               // application.Context.Response.ContentType = "application/json";
                application.CompleteRequest();
            }
        }
        public void Dispose()
        {
        }
    }
