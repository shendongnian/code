    public static bool UsesColor
    {
        get
        {
            try
            {
                //Start menu: 
                //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\
                //CurrentVersion\Themes\Personalize
                var autoColorization = 
                    Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\DWM", 
                        "ColorPrevalence", "0").ToString();
                return autoColorization.Equals("1");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
