    public class Startup
    {
        private readonly AppSettings _appSettings;
        public Startup(IHostingEnvironment env)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            new ConfigurationBuilder()
              .AddEmbeddedJsonFile(assembly, "appsettings.json")
              .AddEmbeddedJsonFile(assembly, $"appsettings.{env.EnvironmentName.ToLower()}.json")
              .Build();
        }
        ...
    }
