    using Microsoft.Win32;
    using System.Reflection;
    const string MuiCacheKeyPath =
        @"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache";
    static void DeleteExecutablePathFromMuiCache()
    {
        string exePath = Assembly.GetExecutingAssembly().Location; // (1)
        using (RegistryKey muiCacheKey = Registry.CurrentUser
            .OpenSubKey(MuiCacheKeyPath, writable: true))
        {
            if (muiCacheKey.GetValueNames().Contains(exePath))
            {
                muiCacheKey.DeleteValue(exePath);
            }
        }
    }
