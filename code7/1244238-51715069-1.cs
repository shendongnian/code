    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<HeadHandler>();
            //The rest of your original startup class goes here
            //app.UseWebApi()
            //app.UseSignalR();
        }
    }
