        public static bool DeviceIsPhone()
        {
            Type StatusBarType = Type.GetType("Windows.UI.ViewManagement.StatusBar, Windows, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime");
            if (StatusBarType != null)
                return true;
            return false;
        }
