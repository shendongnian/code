    public class WebConfigreader
    {
        public static string AppSettingsKey(string key)
        {
            if (WebConfigurationManager.AppSettings != null)
            {
                object xSetting = WebConfigurationManager.AppSettings[key];
                if (xSetting != null)
                {
                    return (string)xSetting;
                }
            }
            return "";
        }
    }
