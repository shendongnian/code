    using (var key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop"))
    {
        if (key != null)
        {
            Boolean isActive = false;
            Boolean isSecure = false;
            Int32 timeoutSeconds = 0;
            var o = key.GetValue("ScreenSaveActive", "");
            if (!String.IsNullOrWhiteSpace(o as String))
            {
                Int32 i;
                if (Int32.TryParse((String)o, out i))
                    isActive = (i == 1);
            }
            o = key.GetValue("ScreenSaverIsSecure", "");
            if (!String.IsNullOrWhiteSpace(o as String))
            {
                Int32 i;
                if (Int32.TryParse((String)o, out i))
                    isSecure = (i == 1);
            }
            o = key.GetValue("ScreenSaveTimeOut", "");
            if (!String.IsNullOrWhiteSpace(o as String))
            {
                Int32 i;
                if (Int32.TryParse((String)o, out i))
                    timeoutSeconds = i;
            }
        }
    }
