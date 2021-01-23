      public partial class Startup
    {
        private static readonly ILog log = 
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod
        ().DeclaringType);
        public void Configuration(IAppBuilder app)
        {
            //Hangfire Config
            GlobalConfiguration.Configuration.UseSqlServerStorage
                ("HangFireJobs");
            app.UseHangfireServer();
            log.Debug("Application Started");
            ConfigureAuth(app);
          
            //this call placement is important
            var options = new DashboardOptions
            {
                Authorization = new[] { new CustomAuthorizationFilter() }
            };
            app.UseHangfireDashboard("/hangfire", options);
        }
    }
