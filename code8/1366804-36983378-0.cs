    public class Startup
    {
        public void Start()
        {
            var options = new StartOptions()
            options.Urls.Add(new Uri("http://*:8084"));
            options.AppStartup(this.GetType().AssemblyQualifiedName;
            var host = WebApp.Start(options, Configuration);
        }
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(OwinContextMiddleware));
            app.UseNancy();
        }
    }
