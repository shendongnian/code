    class Program
    {
        static void Main(string[] args)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (var sectionKey in configuration.Sections.Keys)
            {
                var section = configuration.GetSection(sectionKey.ToString());
                var appSettings = section as AppSettingsSection;
                if (appSettings == null) continue;
                Console.WriteLine(sectionKey);
                foreach (var key in appSettings.Settings.AllKeys)
                {
                    Console.WriteLine("  {0}: {1}", key, appSettings.Settings[key].Value);
                }
            }
            Console.ReadLine();
        }
    }
