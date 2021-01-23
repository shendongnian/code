    //You can either provide User name or SID
    public string GetUserProfilePath(string userName, string userSID = null)
    {
        try
        {
            if (userSID == null)
            {
                userSID = GetUserSID(userName);
            }
            var keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + userSID;
            var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyPath);
            if (key == null)
            {
                //handle error
                return null;
            }
            var profilePath = key.GetValue("ProfileImagePath") as string;
            return profilePath;
        }
        catch
        {
            //handle exception
            return null;
        }
    }
    public string GetUserSID(string userName)
    {
        try
        {
            NTAccount f = new NTAccount(userName);
            SecurityIdentifier s = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
            return s.ToString();
        }
        catch
        {
            return null;
        }
    }
~~~~
