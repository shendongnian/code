    public class OptionsModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var app = (HttpApplication) sender;
                if (app.Request.HttpMethod == "OPTIONS")
                {
                    app.Response.StatusCode = 200;
                    app.Response.AddHeader("Access-Control-Allow-Headers", "content-type");
                    app.Response.AddHeader("Access-Control-Allow-Origin", APISettings.ApplicationOrigin);
                    app.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                    app.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                    app.Response.AddHeader("Content-Type", "application/json");
                    app.Response.End();
                }
            };
        }
        public void Dispose()
        {
        }
    }
