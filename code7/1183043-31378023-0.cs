    private static string GetUserEmailAddressVS14()
    {
        // It's a good practice to request explicit permission from
        // the user that you want to use his email address and any
        // other information. This enables the user to be in control
        // of his/her privacy.
    
        // Assuming permission is granted, we obtain the email address.
    
        const string SubKey = "Software\\Microsoft\\VSCommon\\ConnectedUser\\IdeUser\\Cache";
        const string EmailAddressKeyName = "EmailAddress";
        const string UserNameKeyName = "DisplayName";
    
        RegistryKey root = Registry.CurrentUser;
        RegistryKey sk = root.OpenSubKey(SubKey);
        if (sk == null)
        {
            // The user is currently not signed in.
            return null;
        }
        else
        {
            // Get user email address.
            return (string)sk.GetValue(EmailAddressKeyName);
    
            // You can also get user name like this.
            // return (string)sk.GetValue(UserNameKeyName);
        }
    }
