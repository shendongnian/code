    public class ConfigManager
    {
        public string IPAddress
        {
             get
             {
                 if (ConfigurationManager.AppSettings.Keys.Any(k => k == "IPAddr"))
                     return ConfigurationManager.AppSettings.GetValues("IPAddr");
                 return null;
             }
             set
             {
                 if (ConfigurationManager.AppSettings.Keys.Any(k => k == "IPAddr"))
                     ConfigurationManager.AppSettings.Remove("IPAddr");
                 ConfigurationManager.AppSettings.Add("IPAddr", value);
             } 
        }
