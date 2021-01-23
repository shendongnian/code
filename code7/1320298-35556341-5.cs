    public class Program
    {
        public static void Main(string[] args)
        {
            var container = GetIoC();
            container.Bind<App>().ToSelf();
            container.Bind<IAppBuilder>().To(()=>new AppBuilder());
            container.Bind<HttpConfiguration>();
            // ... other bindings you need 
            
            //resolve root
            var app = container.Get<App>();
            app.Start(); 
        }
    }
