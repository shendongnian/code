        public class Startup {
            public void Configuration(IAppBuilder app) {
                var hubConfiguration = new HubConfiguration();
                hubConfiguration.EnableDetailedErrors = true;
                app.MapSignalR(hubConfiguration);
            }
        }
