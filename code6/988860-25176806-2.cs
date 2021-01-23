    public static class CustomConfigurationManager
        {
    
            private static string pwd = "ThisIsNotBestPracticeForStoringPasswords".Select(x => x.ToString() + (x + 2).ToString()).Aggregate((current, next) => current + next);
    
            public static AppSettingsIndexer AppSettings = new AppSettingsIndexer(pwd);
            public static ConnectionStringsIndexer ConnectionStrings = new ConnectionStringsIndexer(pwd);
    
            public static void CheckConfig()
            {
    
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = config.AppSettings;
                var connectionStrings = config.ConnectionStrings.ConnectionStrings;
    
                if (!appSettings.Settings.AllKeys.Contains("Encrypted"))
                {
                    EncryptConfig(pwd, config, appSettings, connectionStrings);
                }
            }
    
            private static void EncryptConfig(string pwd, Configuration config, AppSettingsSection appSettings, ConnectionStringSettingsCollection connectionStrings)
            {
                foreach (var key in appSettings.Settings.AllKeys)
                {
                    appSettings.Settings[key].Value = StringCipher.Encrypt(appSettings.Settings[key].Value, pwd);
                }
               
                for (int i = 0; i < connectionStrings.Count; i++)
                {
                    connectionStrings[i] = new ConnectionStringSettings(connectionStrings[i].Name, StringCipher.Encrypt(connectionStrings[i].ConnectionString, pwd), connectionStrings[i].ProviderName);
                }
    
                appSettings.Settings.Add("Encrypted", "True");
                config.Save(ConfigurationSaveMode.Modified, true);
            }
    
            
            static class StringCipher
            {
                internal static string Encrypt(string plainText, string passPhrase)
                {
                    if (plainText.Trim() == "")
                        return "";
    
                    /* Add your encryption stuff here */
                }
    
                internal static string Decrypt(string cipherText, string passPhrase)
                {
                    if (cipherText.Trim() == "")
                        return "";
    
                    /* Add decryption stuff here */
                }
            }
    
            public class AppSettingsIndexer
            {
                static string pwd;
    
                public AppSettingsIndexer(string _pwd)
                {
                    pwd = _pwd;
                }
    
                public string this[string index]
                {
                    get
                    {
                        return StringCipher.Decrypt(ConfigurationManager.AppSettings[index], pwd);
                    }
                }
            }
    
            public class ConnectionStringsIndexer
            {
                static string pwd;
    
                public ConnectionStringsIndexer(string _pwd)
                {
                    pwd = _pwd;
                }
    
                public string this[string index]
                {
                    get
                    {
                        var connectionString = ConfigurationManager.ConnectionStrings[index];
                        return new ConnectionStringSettings(connectionString.Name, StringCipher.Decrypt(connectionString.ConnectionString, pwd), connectionString.ProviderName).ToString();
                    }
                }
            }
    
        }
