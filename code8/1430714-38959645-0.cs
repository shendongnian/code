    public static void CreateUser(string userName, string password){
        UserPrincipal user = new UserPrincipal(ContextType.Domain);
        user.SetPassword(password);
        user.Name = userName;
        user.SamAccountName = userName;
        user.UserPrincipalName = userName;
        user.Save();
        // Now that the account has been created and has a password, you can enable it
        user.Enabled = true;
        user.Save();
    }
