    [assembly: OwinStartup(typeof(YourApp.Startup))] // Change YourApp to your base namespace
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfire(config => 
            {
                config.UseSqlServerStorage("NameOfConnectionStringKey"); // Other storage options are available
                config.UseDashboardPath("/hangfire");
                config.UseServer();
            });
        }
    }
