    public class ConfigurationModel
    {
        public ConfigurationModel() {
            AppSettingsValues  = new List<KeyValuePair<string, string>>();
        }
    
        public List<KeyValuePair<string, string>> AppSettingsValues { get; set; }
    }
