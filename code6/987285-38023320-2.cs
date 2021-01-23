    using System.Configuration;
    using System.IO;
    using System.Web.Configuration;
    namespace YourNamespace
    {
        public static class DotNetConfigFile
        {
            public static Configuration GetConfiguration(string filePath)
            {
                if (File.Exists(filePath))
                {
                    FileInfo file = new FileInfo(filePath);
                    if (file.Name.ToLower() != "web.config")
                    {
                        try
                        {
                            ExeConfigurationFileMap map = new ExeConfigurationFileMap() { ExeConfigFilename = filePath };
                            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                        }
                        catch (ConfigurationErrorsException ex)
                        {
                            return null;
                            //throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            var virtualDirectoryMapping = new VirtualDirectoryMapping(file.DirectoryName, true, file.Name);
                            var webConfigFileMap = new     WebConfigurationFileMap();
                            webConfigFileMap.VirtualDirectories.Add("/",     virtualDirectoryMapping);
                            return WebConfigurationManager.OpenMappedWebConfiguration(webConfigFileMap, "/");
                        }
                        catch(ConfigurationErrorsException ex)
                        {
                            return null;
                            //throw;
                        }
                    }
                }
                else
                    throw new FileNotFoundException("File not found", filePath);
            }
    
            public static KeyValueConfigurationCollection GetAppSettings(string filePath)
            {
                var config = GetConfiguration(filePath);
                if (config != null)
                    return config.AppSettings.Settings;
                else
                    return null;
            }
    
            public static KeyValueConfigurationCollection GetAppSettings(FileInfo fileInfo)
            {
                return GetAppSettings(fileInfo.FullName);
            }
    
            public static ConnectionStringSettingsCollection GetConnectionStrings(string filePath)
            {
                var config = GetConfiguration(filePath);
                if (config != null)
                    return config.ConnectionStrings.ConnectionStrings;
                else
                    return null;
            }
        public static ConnectionStringSettingsCollection GetConnectionStrings(FileInfo fileInfo)
        {
            return GetConnectionStrings(fileInfo.FullName);
        }
    }
