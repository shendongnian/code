    using System.Configuration; // Requires a reference to assembly System.Configuration
    public static class ConfigurationEncryptor {
        [Flags]
        public enum ConfigurationSectionType {
            ConnectionStrings = 1,
            ApplicationSettings = 2
        }
        public static bool Encrypt(ConfigurationSectionType section) {
            bool result = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config == null)
                throw new Exception("Cannot open the configuration file.");
            if (section.HasFlag(ConfigurationSectionType.ConnectionStrings)) {
                result = result || EncryptSection(config, "connectionStrings");
            }
            if (section.HasFlag(ConfigurationSectionType.ApplicationSettings)) {
                result = result || EncryptSection(config, "appSettings");
            }
            return result;
        }
        private static bool EncryptSection(Configuration config, string section) {
            ConfigurationSection currentSection = config.GetSection(section);
            if (currentSection == null)
                throw new Exception("Cannot find " + section + " section in configuration file.");
            if (!currentSection.SectionInformation.IsProtected) {
                currentSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                config.Save();
                // Refresh configuration
                ConfigurationManager.RefreshSection(section);
                return true;
            }
            return false;
        }
    }
