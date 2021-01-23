    class Program
    {
        static void Main(string[] args)
        {
            // Make sure we don't overwrite the previous run's settings.
            if (String.IsNullOrEmpty(Settings.Default.SettingsObjects))
            {
                // Create the initial settings.
                var list = new SettingsList<SettingsObject> { 
                    new SettingsObject { Property = "alpha" }, 
                    new SettingsObject { Property = "beta" }
                };
                Console.WriteLine("settingsObject.Property[0] is {0}", list[0].Property);
                //Save initial values to Settings
                Settings.Default.SettingsObjects = list.ToBase64();
                Settings.Default.Save();
                // Change a property
                list[0].Property = "theta";
                // This is where you went wrong, settings will not be persisted at this point
                // because you have only modified the in memory list.
                
                // You need to set the property on settings again to persist the value.
                Settings.Default.SettingsObjects = list.ToBase64();
                Settings.Default.Save();
            }
            // pull that property back out & make sure it saved.
            var deserialized = SettingsList<SettingsObject>.FromBase64(Settings.Default.SettingsObjects);
            Console.WriteLine("settingsObject.Property[0] is {0}", deserialized[0].Property);            
            Console.WriteLine("Finished! Press any key to continue.");
            Console.ReadKey();
        }
    }
