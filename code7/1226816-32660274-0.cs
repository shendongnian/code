    class RequestInterceptor : IHttpModule
    {
        public void Dispose()
        {
    
        }
    
        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }
    
        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
    
            //Inspect the URL and decide if this is a request you are interested in
            //context.Request.Url
            //context.Request.QueryString
    
            //Redirect, or whatever...
            //context.Response.Redirect(...)
    
        }
    }
