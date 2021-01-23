        public class Startup
        {
          public Startup(IConfiguration configuration)
          {
            Configuration = configuration;
          }
          public IConfiguration Configuration { get; }
          public static string UserNameFromAppSettings { get; private set; }
          public static string PasswordFromAppSettings { get; private set; }
 
          //set username and password from appsettings.json
          UserNameFromAppSettings = Configuration.GetSection("BasicAuth").GetSection("UserName").Value;
          PasswordFromAppSettings = Configuration.GetSection("BasicAuth").GetSection("Password").Value;
        }
 
 
