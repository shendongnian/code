    public class MyModule : IHttpModule 
    {
    
        public void Init(HttpApplication application)
        {
            //hook your onload event here. There are other events that could be more suitable
            app.PreRequestHandlerExecute += OnBeforeExecute;
        }
        private void OnBeforeExecute(Object sender, EventArgs e)
        {
            var app = (HttpApplication) sender;
            HttpContext context = app.Context;
            //insert your code here
        }
        public void Dispose()
        {
        }
    }
