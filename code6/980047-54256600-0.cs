    List<string> gInstalledSoftware
            void GetInstalledSoftwareList()
            {
                string displayName;
    
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
                {                
                    foreach (String keyName in key.GetSubKeyNames())
                    {
                        RegistryKey subkey = key.OpenSubKey(keyName);
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (string.IsNullOrEmpty(displayName))
                            continue;
    
                        gInstalledSoftware.Add(displayName.ToLower());
                    }
                }
                
                //using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
                using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    var key = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);
                    foreach (String keyName in key.GetSubKeyNames())
                    {
                        RegistryKey subkey = key.OpenSubKey(keyName);
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (string.IsNullOrEmpty(displayName))
                            continue;
    
                        gInstalledSoftware.Add(displayName.ToLower());
                    }
                }
    
                using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    var key = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);
                    foreach (String keyName in key.GetSubKeyNames())
                    {
                        RegistryKey subkey = key.OpenSubKey(keyName);
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (string.IsNullOrEmpty(displayName))
                            continue;
    
                        gInstalledSoftware.Add(displayName.ToLower());
                    }
                }
    
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall",false))
                {
                    foreach (String keyName in key.GetSubKeyNames())
                    {
                        RegistryKey subkey = key.OpenSubKey(keyName);
                        displayName = subkey.GetValue("DisplayName") as string;
                        if (string.IsNullOrEmpty(displayName))
                            continue;
    
                        gInstalledSoftware.Add(displayName.ToLower());
                    }
                }             
            } 
