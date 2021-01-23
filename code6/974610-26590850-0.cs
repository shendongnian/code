    public class SwaggerConfig
    {
        private const string AllowSwaggerUsageAppSetting = "AllowSwaggerAccess";
    
        public static void Register()
        {
            if (AllowSwaggerAccess)
            {
                Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);
            }
    
            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...
        }
    
        private static bool AllowSwaggerAccess
        {
            get
            {
                bool _parsedValue;
    
                return bool.TryParse(ConfigurationManager.AppSettings[AllowSwaggerUsageAppSetting] ?? "false", out _parsedValue) && _parsedValue;
            }
        }
    }
