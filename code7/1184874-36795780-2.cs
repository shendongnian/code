    using Owin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Diagnostics;
    using Castle.Windsor;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.Tracing;
    namespace Web.Api.Host
    {
        class Startup
        {
            private readonly IWindsorContainer _container;
            public Startup()
            {
                _container = new WindsorContainer().Install(new WindsorInstaller());
            }
            public void Configuration(IAppBuilder appBuilder)
            {
                var properties = new Microsoft.Owin.BuilderProperties.AppProperties(appBuilder.Properties);
                var token = properties.OnAppDisposing;
                if (token != System.Threading.CancellationToken.None)
                {
                    token.Register(Close);
                }
                appBuilder.UsePerWebRequestLifestyleOwinMiddleware();
                
                //
                // Configure Web API for self-host. 
                //
                HttpConfiguration config = new HttpConfiguration();
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            }
            public void Close()
            {
                if (_container != null)
                    _container.Dispose();
            }
        }
    }
