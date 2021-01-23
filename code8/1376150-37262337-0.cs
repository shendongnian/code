    public class WebServer : IDisposable
    {
        private static IDisposable WebApplication = null;
        private static WebServer _Instance = null;
        public static GetInstance()
        {
            //other tests before here
            if(_Instance == null)
            {
                 WebApplication = Microsoft.Owin.Hosting.WebApp.Start<WebServer>("localhost:12345");
                 _Instance = new WebServer();
                 _Instance._HostAddress = hostAddress;
            }
        }
    
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            // other config
        }
    
        public void Dispose()
        {
            if (WebApplication != null)
                WebApplication.Dispose();
            WebApplication = null;
            _Instance = null;
        }
    }
    
    WebServer webserver = WebServer.GetInstance();
    //later
    webserver.Dispose();
