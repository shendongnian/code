            public static class StartupHelpers
        {
              public static bool HasTriggeredFromUrl(out string uri)
               {
                try
                {
                    uri = string.Empty;
                    var activeUri = ApplicationDeployment.CurrentDeployment.ActivationUri;
                    uri = activeUri != null ? activeUri.ToString() : string.Empty;
                    return true;
                }
                catch (InvalidDeploymentException inv)
                {
                    uri = string.Empty;
                    return false;
                }
            }
            public static bool IsTriggeredFromLink(Uri activationUri, out int queryStringValue)
            {
                queryStringValue = 0;
                var hasTriggeredFromLink = true;
                if (string.IsNullOrWhiteSpace(activationUri.Query) ||
                    HttpUtility.ParseQueryString(activationUri.Query).Count <= 0)
                    hasTriggeredFromLink = false;
                else
                {
                    if (!int.TryParse(HttpUtility.ParseQueryString(activationUri.Query)[0], out queryStringValue))
                        throw new Exception("Invalid startup argument found from web site.");
                }
                return hasTriggeredFromLink;
            }
            public static bool SetConfigurationValue(string key, string value)
            {
                try
                {
                    Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    appConfig.AppSettings.Settings[key].Value = value;
                    appConfig.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            public static string GetConfigurationValue(string key)
            {
                try
                {
                    Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationManager.RefreshSection("appSettings");
                    return appConfig.AppSettings.Settings[key].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
