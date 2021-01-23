        static void Main(string[] args)
        {
            //To retrieve the last saved tab index
            String LastSelectedTab = RestoreSettings.Properties.Settings.Default.CurrentSelectedTab;
            
            Console.WriteLine(LastSelectedTab);
            //To save the current selected tab index
            RestoreSettings.Properties.Settings.Default.CurrentSelectedTab = 2;
            RestoreSettings.Properties.Settings.Default.Save();
        }
