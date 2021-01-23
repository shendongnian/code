    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(new PathString("/api"), site => ConfigureAuth2(site));
            ConfigureAuth(app);
            
        }
    }
