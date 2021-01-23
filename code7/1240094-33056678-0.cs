    public static bool IsApplictionInstalled(string p_name)
    {
        string displayName;
        RegistryKey key;
    
        // search in: CurrentUser
        key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
        foreach (String keyName in key.GetSubKeyNames())
        {
            RegistryKey subkey = key.OpenSubKey(keyName);
            displayName = subkey.GetValue("DisplayName") as string;
            if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
        }
    
        // search in: LocalMachine_32
        key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
        foreach (String keyName in key.GetSubKeyNames())
        {
            RegistryKey subkey = key.OpenSubKey(keyName);
            displayName = subkey.GetValue("DisplayName") as string;
            if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
        }
    
        // search in: LocalMachine_64
        key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
        foreach (String keyName in key.GetSubKeyNames())
        {
            RegistryKey subkey = key.OpenSubKey(keyName);
            displayName = subkey.GetValue("DisplayName") as string;
            if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
        }
    
        // NOT FOUND
        return false;
    }
