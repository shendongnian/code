        static void Main(string[] args)
        {
            string configPath = @"..\..\App.config";
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = configPath;
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            for (int i = 0; i < config.SectionGroups.Count; i++)
            {
                Console.WriteLine(config.SectionGroups[i].SectionGroupName);
            }
        }
