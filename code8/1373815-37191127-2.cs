    public class ApplicationConfig : IApplicationConfig
    {
        public ConnectionStringSettingsCollection GetConnectionStrings()
        {
            return ConfigurationManager.ConnectionStrings;
        }
    }
