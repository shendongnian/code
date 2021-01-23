    using Nowin;
    using Owin;
    using Owin.Builder;
    
    public class App
    {
        public static void Main(string[] args)
        {
            var container = GetIoC();
            var owinAppBuilder = (IAppBuilder)new AppBuilder();
            var provider = container.Get<ISomeServiceProvider>();
            var config = container.Get<HttpConfiguration>();
            ConfigureOAuth(owinAppBuilder, provider);
            owinAppBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            owinAppBuilder.UseWebApi(config);
            //Build Owin App
            var owinApp = (AppFunc)owinAppBuilder.Build(typeof(AppFunc));
            //Make an endpoint
            var owinEndpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 8080);
            //Build WebServer (Nowin)
            var owinServer = ServerBuilder.New()
                .SetOwinApp(owinApp)
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
        public static IContainer GetIoC()
        {
            return new ConfiguredIoCContainer();
        }
        ...
    }
