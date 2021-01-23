    using Microsoft.Extensions.PlatformAbstractions;
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
        // Setup configuration sources.
        var builder = new ConfigurationBuilder()
           .SetBasePath(appEnv.ApplicationBasePath)
           ....
    }
