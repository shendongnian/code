    string registry_key_32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    string registry_key_64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
    using(Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key_32))
    {
        foreach(string name in key.GetSubKeyNames())
        {
            using(RegistryKey subkey = key.OpenSubKey(name))
            {
                Console.WriteLine(subkey.GetValue("DisplayName"));
            }
        }
    }
    // And...
    using(Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key_64))
    {
        foreach(string name in key.GetSubKeyNames())
        {
            using(RegistryKey subkey = key.OpenSubKey(name))
            {
                Console.WriteLine(subkey.GetValue("DisplayName"));
            }
        }
    }
