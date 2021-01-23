    public class Startup
    {
        private readonly IApplicationEnvironment _appEnv;
    
        public Startup(IApplicationEnvironment appEnv)
        {
            _appEnv = appEnv;
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            string basePath = _appEnv.ApplicationBasePath;
        }
    }
