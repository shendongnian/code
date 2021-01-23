    public class Global : System.Web.HttpApplication
    {
        public static SiteBackgroundCaller BackgroundCaller { get; private set; }
        protected void Application_Start(object sender, EventArgs e)
        {
            BackgroundCaller = new SiteBackgroundCaller();
        }
    }
