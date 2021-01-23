    public async Task<List<Apps>> GetAllApps()
    {
        List<Apps> _installedApps = new List<Apps>();
        _installedApps.AddRange(await this.LoadFiles(Registry.CurrentUser,
                        @"Software\Microsoft\Windows\CurrentVersion\Uninstall"));
        _installedApps.AddRange(await this.LoadFiles(Registry.LocalMachine,
                        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"));
        _installedApps.AddRange(await this.LoadFiles(Registry.LocalMachine,
                        @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"));
        return _installedApps.OrderBy(x => x.DisplayName).ToList();
    }
    private async Task<List<Apps>> LoadFiles(RegistryKey rkey, string regkeypath)
            {
                List<Apps> appList = new List<Apps>();
    
                RegistryKey regkey = 
                    rkey.OpenSubKey(regkeypath, 
                    RegistryKeyPermissionCheck.ReadSubTree, 
                    RegistryRights.ReadKey);
    
                if (regkey == null) goto last;
    
                foreach (string subkey in regkey.GetSubKeyNames())
                {
                    if (subkey == null) continue;
    
                    using (RegistryKey key = regkey.OpenSubKey(subkey))
                    {
                        if (key == null) continue;
    
                        // Validating
                        var rType = (string)key.GetValue("ReleaseType");
                        var sComponent = key.GetValue("SystemComponent");
                        var pName = (string)key.GetValue("ParentDisplayName");
                        var dName = (string)key.GetValue("DisplayName");
    
                        if (!string.IsNullOrEmpty(dName) && string.IsNullOrEmpty(rType) && string.IsNullOrEmpty(pName) && (sComponent == null))
                            appList.Add(await ReadKeyValues(key));
    
                        key.Flush();
                        key.Close();
                    }
                }
    
                regkey.Flush();
                regkey.Close();
    
            last:
                return appList;
            }
            private Task<string> GetIconForRoot(string productName)
            {
                string result = string.Empty;
                string installerKey = @"Installer\Products";
    
                bool isFound = false;
    
                RegistryKey regkey = Registry.ClassesRoot.OpenSubKey(installerKey, 
                    RegistryKeyPermissionCheck.ReadSubTree, 
                    RegistryRights.ReadKey);
    
                if (regkey == null) goto last;
    
                foreach (string subkey in regkey.GetSubKeyNames())
                {
                    if (subkey == null) continue;
    
                    using (RegistryKey key = regkey.OpenSubKey(subkey))
                    {
                        if (key.GetValue("ProductName") != null)
                            if (productName == key.GetValue("ProductName").ToString())
                                if (key.GetValue("ProductIcon") != null)
                                {
                                    isFound = true;
                                    result = key.GetValue("ProductIcon").ToString();
                                }
                        key.Flush();
                        key.Close();
    
                        if (isFound) break;
                    }
                }
    
                regkey.Flush();
                regkey.Close();
    
            last:
                return Task.FromResult(result);
            }
            private async Task<Apps> ReadKeyValues(RegistryKey key)
            {
                Apps installedApp = new Apps();
    
                installedApp._displayName = key.GetValue("DisplayName") == null ? string.Empty : (string)key.GetValue("DisplayName");
                installedApp._publisher = key.GetValue("Publisher") == null ? string.Empty : (string)key.GetValue("Publisher");
                installedApp._installDate = key.GetValue("InstallDate") == null ? string.Empty : (string)key.GetValue("InstallDate");
    
                var decValue = key.GetValue("EstimatedSize") == null ? "0" : key.GetValue("EstimatedSize");
                installedApp._estimatedSize = decValue.ToString() == "0" ? string.Empty : Common.GetSize(decValue.ToString());
    
                installedApp._systemIcon = key.GetValue("DisplayIcon") == null ? string.Empty : (string)key.GetValue("DisplayIcon");
    
                if (string.IsNullOrEmpty(installedApp._systemIcon) && !string.IsNullOrEmpty(installedApp._displayName))
                    installedApp._systemIcon = await this.GetIconForRoot(installedApp._displayName);
    
    
                if (!string.IsNullOrEmpty(installedApp._systemIcon))
                    installedApp._systemIcon = installedApp._systemIcon.Replace("\"", string.Empty).Trim();
    
                installedApp._displayVersion = key.GetValue("DisplayVersion") == null ? string.Empty : (string)key.GetValue("DisplayVersion");
                installedApp._uninstallString = key.GetValue("UninstallString") == null ? string.Empty : (string)key.GetValue("UninstallString");
                installedApp._modifyPath = key.GetValue("ModifyPath") == null ? string.Empty : (string)key.GetValue("ModifyPath");
    
                Common.FileSize += Int32.Parse(decValue.ToString());
    
                return installedApp;
            }
