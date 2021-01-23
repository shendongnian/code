    public HelpController(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new AssemblyResolver());
            Configuration = config;
        }
