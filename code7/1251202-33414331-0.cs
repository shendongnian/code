        string keyname = "SAVCE";
        Console.WriteLine(Read(keyname));    
        public static string Read(string KeyName)
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Symantec\InstalledApps"))
            {
                return (string)registryKey.GetValue(KeyName);
            }
        }
