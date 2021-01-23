    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            AppSettings settings = new AppSettings();
    
            Configuration = configuration;
            configuration.Bind(settings);
            //now start using it
            string setting1 = settings.Setting1;
            int setting2 = settings.Setting2;
        }
