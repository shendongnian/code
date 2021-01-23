        public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureContainer(app);
            ConfigureAuth(app);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
