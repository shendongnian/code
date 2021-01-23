    public static bool IsQuietHours()
    {
        string path = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
        string key = "NOC_GLOBAL_SETTING_TOASTS_ENABLED";
        int? toastsEnabled = (int?)Microsoft.Win32.Registry.GetValue(path, key, 1);
        if (toastsEnabled == 0)
            return true; 
        return false;
    }
