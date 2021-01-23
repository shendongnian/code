    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment applicationEnvironment)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            Configuration = builder.Build().ReloadOnChanged("appsettings.json");
            var basePath = applicationEnvironment.ApplicationBasePath;
            var libPath = Path.Combine(basePath, "approot");
            LibraryLoader.Instance.CustomSearchPath = libPath;
            TessDataPath = Path.Combine(basePath, "approot\\tessdata");
        }
    ...
    }
