     [assembly: OwinStartupAttribute(typeof(yournamespace.Startup))]
        namespace yournamespace    
        public partial class Startup
                {
                    public void Configuration(IAppBuilder app)
                    {
                       
                        var storage = new SqlServerStorage("connectionstring");
                      
                        ......
                        ......
                        app.UseHangfireDashboard("/Scheduler", new DashboardOptions() { AuthorizationFilters = new[] { new HangFireAuthorizationFilter() } }, storage);
                    }
