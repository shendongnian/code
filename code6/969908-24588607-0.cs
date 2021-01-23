    public class MYAppConfigTool {
        private Configuration _cfg;
        public Configuration GetConfig() {
            if (_cfg == null) {
                if (HostingEnvironment.IsHosted) // running inside asp.net ?
                { //yes so read web.config at hosting virtual path level
                    _cfg = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
                }
                else { //no, se we are testing or running exe version admin tool for example, look for an APP.CONFIG file
                    //var x = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                    _cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
            }
            return _cfg;
        }
        public AppSettingsSection GetAppSettings() {
            var cfg = GetConfig();
            return cfg == null ? null 
                               : cfg.AppSettings;
        }
        public string GetAppSetting(string key) {
            // null ref here means key missing.   DUMP is good.   ADD the missing key !!!!
            var cfg = GetConfig();
            if (cfg == null) return null;
            var appSettings = cfg.AppSettings;
            return appSettings == null ? null 
                                       : GetConfig().AppSettings.Settings[key].Value;
        }
    }
