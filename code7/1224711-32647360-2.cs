            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var group = (NetSectionGroup)config.GetSectionGroup("system.net");
            if (group.Settings.PerformanceCounters.Enabled)
            {
                Console.WriteLine("ENABLED");
            }
