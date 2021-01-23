    public class DefaultRegistry: Registry
    {
        public static IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(HttpRuntime.AppDomainAppPath)
            .AddJsonFile("appsettings.json")
            .Build();
        public DefaultRegistry()
        {
            For<IConfiguration>().Use(() => Configuration);  
            
