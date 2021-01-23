    public class AppHost : AppHostBase
    {
        //Tell ServiceStack the name of your app and which assemblies to scan for services
        public AppHost() : base("Hello ServiceStack!", 
           typeof(ServicesFromDll1).Assembly,
           typeof(ServicesFromDll2).Assembly
           /*, etc */) {}
    
        public override void Configure(Container container) {}
    }
