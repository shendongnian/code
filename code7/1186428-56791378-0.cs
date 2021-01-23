    public class Settings
        {
            private static IHttpContextAccessor _HttpContextAccessor;
            public Settings(IHttpContextAccessor httpContextAccessor)
            {
                _HttpContextAccessor = httpContextAccessor;
            }
            public static void Configure(IHttpContextAccessor httpContextAccessor)
            {
                _HttpContextAccessor = httpContextAccessor;
            }
            public static IConfigurationBuilder Getbuilder()
            {
                var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
                return builder;
            }
    
            public static string GetAppSetting(string key)
            {
                //return Convert.ToString(ConfigurationManager.AppSettings[key]);
                var builder = Getbuilder();
                var GetAppStringData = builder.Build().GetValue<string>("AppSettings:" + key);
                return GetAppStringData;
            }
    
            public static string GetConnectionString(string key="DefaultName")
            {
                var builder = Getbuilder();
                var ConnectionString = builder.Build().GetValue<string>("ConnectionStrings:"+key);
                return ConnectionString;
            }
    	}
