    public static bool LockSettingsAreCompliant()
    {
        bool lockSettingsAreCompliant = false;
        try
        {
            using (var regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
            {
                lockSettingsAreCompliant =
                    regKey.GetValue("ScreenSaveActive").ToString() == "1" &&
                    regKey.GetValue("ScreenSaverIsSecure").ToString() == "1" &&
                    int.Parse(regKey.GetValue("ScreenSaveTimeOut").ToString()) <= 900;
            }
        }
        catch
        {
            // Swallow exceptions and let the method return false
        }
        return lockSettingsAreCompliant;
    }
