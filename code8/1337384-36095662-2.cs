    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Logging;
    using NLog.Web;
    using NLog.Extensions.Logging;
    
    public class Startup
    {
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            //add NLog to aspnet5
            loggerFactory.AddNLog();
    
            //add NLog.Web (only needed if NLog.Web.ASPNET5 is needed)
            app.AddNLogWeb();
    
            //configure nlog.config in your project root
            env.ConfigureNLog("./DeleteLogs/nlog.config");
            
            // we can also do this from a controller
            // if we inject ILoggerFactory
            var logger = loggerFactory.CreateLogger("NLog Demo"); 
            logger.LogInformation("Hello from NLog");
        }    
    }
