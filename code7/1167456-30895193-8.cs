    static string GetVisualStudioInstallationFolder(string visualStudioVersion)
    {
        string subKeyName = string.Format(
            CultureInfo.InvariantCulture, 
            @"Software\Microsoft\VisualStudio\{0}_Config", 
            visualStudioVersion);
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyName))
        {
            if (key != null)
            {
                return (string)key.GetValue("ShellFolder");
            }
        }
        return null;
    }
