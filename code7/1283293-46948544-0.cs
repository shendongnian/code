    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //this value default is 1000
            GlobalHost.Configuration.DefaultMessageBufferSize = 32;
            app.MapSignalR();
        }
    }
