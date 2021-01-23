    namespace ABC
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
                app.MapSignalR(); <--{Add this line}
            }        
        }
    }
