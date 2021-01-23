    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Owin;
    using Microsoft.Owin.Cors;
    using System.Web.Cors;
    
    [assembly: OwinStartup(typeof(SignalRSelfHost.Startup))]
    
    namespace SignalRSelfHost
    {
        public class Startup
        {
    
            public void Configuration(IAppBuilder app)
            {
                var policy = new CorsPolicy()
                {
                    AllowAnyHeader = true,
                    AllowAnyMethod = true,
                    SupportsCredentials = true
                };
    
                policy.Origins.Add("domain"); //be sure to include the port:
    //example: "http://localhost:8081"
    
                app.UseCors(new CorsOptions
                {
                    PolicyProvider = new CorsPolicyProvider
                    {
                        PolicyResolver = context => Task.FromResult(policy)
                    }
                });
    
                app.MapSignalR();
            }
        }
    }
