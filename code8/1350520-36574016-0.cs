            private static string TryGetDefaultCategory()
            {
                string result = null;
                try
                {
                    var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
                    var loggingSection =
                            configuration.Sections.OfType<Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings>().First();
                    result = loggingSection?.DefaultCategory;
                }
                catch (Exception ex)
                {
                    // Error("[Logging] Failed to get Default Category", ex);
                }
                return result;
            }
