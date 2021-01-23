    internal class Crypto
    {
        internal static AppSettingsSection GetEncryptedAppSettingsSection(string exeConfigName)
        {
            // Open the configuration file and retrieve 
            // the connectionStrings section.
            System.Configuration.Configuration config = ConfigurationManager.
                OpenExeConfiguration(exeConfigName);
            AppSettingsSection section =
                    config.GetSection("appSettings")
                    as AppSettingsSection;
            EncryptConfigSection(config, section);
            return section;
        }
        internal static ConnectionStringsSection GetEncryptedConnectionStringsSection(string exeConfigName)
        {
            // Open the configuration file and retrieve 
            // the connectionStrings section.
            System.Configuration.Configuration config = ConfigurationManager.
                OpenExeConfiguration(exeConfigName);
            ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;
            EncryptConfigSection(config, section);
            return section;
        }
        internal static void EncryptConfigSection(System.Configuration.Configuration config, ConfigurationSection section)
        {
            //Ensure config sections are always encrypted
            if (!section.SectionInformation.IsProtected)
            {
                // Encrypt the section.
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                // Save the current configuration.
                config.Save();
            }
        }
    }
