    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idProvider = new UserIdProvider();
    	    GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
    
            // TODO configure signalR here
        }
    }
