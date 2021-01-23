    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class App
    {
        private IAppBuilder _appBuilder;
        private HttpConfiguration _config;
        private ISomeServiceProvider _provider;
        public App(IAppBuilder appBuilder, ISomeServiceProvider provider, HttpConfiguration config)
        {
            _appBuilder = appBuilder;
            _provider = provider;
            _config = config;
            
            ConfigureOAuth(_appBuilder, provider);
            _appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            _appBuilder.UseWebApi(config);
            //Build Owin App
            _owinApp = (AppFunc) _appBuilder.Build(typeof (AppFunc));
        }
        void ConfigureOAuth(IAppBuilder app)
        {
            //...
        }
        public void Start()
        {
            //Make an endpoint
            var owinEndpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 8080);
            //Build WebServer (Nowin)
            var owinServer = ServerBuilder.New()
                .SetOwinApp(_owinApp)
                .SetEndPoint(owinEndpoint)
                .Build();
            // Start WebServer
            using (owinServer)
            {
                owinServer.Start();
                Console.WriteLine("Press ENTER to stop");
                Console.ReadLine();
            }
        }
    }
