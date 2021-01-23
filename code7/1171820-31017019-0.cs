    namespace ConsoleApplication58
    {
        class Program
        {
            static void Main(string[] args)
            {
                UpdateConfigurationFile();
            }
    
            private static void UpdateConfigurationFile()
            {
                var oldSetting = Settings1.Default.Server; //to get the current setting if you want..
                Settings1.Default.Server = "localhost2"; //to change the setting.
                Settings1.Default.Save(); //to save settings.
            }
        }
    }
