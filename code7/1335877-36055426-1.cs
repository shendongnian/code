    using Microsoft.AspNet.Builder;
    namespace Environments
    {
        public class StartupStaging
        {
            public void Configure(IApplicationBuilder app)
            {
                app.UseWelcomePage();
            }
        }
    }
    namespace Environments
    {
        public class Startup
        {
            public void Configure(IApplicationBuilder app)
            {
                app.UseWelcomePage();
            }
        }
    }
