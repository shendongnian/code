    public class DatabaseSwitchModule : IHttpModule
    {
        private HttpApplication httpApp;
        public void Init(HttpApplication httpApp)
        {
            this.httpApp = httpApp;
            httpApp.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
        }
        
        public void OnPreRequestHandlerExecute(object sender, EventArgs e)
        {
            NameValueCollection form = httpApp.Request.Form;
            if (form["database"] != null)
            {
                httpApp.Session["database"] = form["database"];
            }
        }
    }
