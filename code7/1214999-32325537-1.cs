    public static string CreateUser(string username, string password)
    {
        //CREATE CONNECTION TO ACTIVE DIRECTORY
        using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "contosco-test.com"))
        {
            //CREATE A NEW USERPRINCIPAL OBJECT
            using (UserPrincipal principal = new UserPrincipal(ctx))
            {
                principal.Enabled = true; //IF NOT ENABLED YOU CAN'T AUTHENTICATE THE USER
                principal.UserPrincipalName = username;
                principal.Name = "name";
                principal.DisplayName = "firstname lastname";
                principal.EmailAddress = "email@test.com";
                principal.VoiceTelephoneNumber = "12345678910";
                principal.GivenName = "firstname";
                principal.Surname = "lastname";
                principal.SetPassword(password);
                try
                {
                   principal.Save();
                }
                catch(Exception ex)           
                {
                    throw;
                }
                //SEARCH FOR THE USER THAT JUST HAS BEEN CREATED
                using (var newUser = UserPrincipal.FindByIdentity(ctx, IdentityType.UserPrincipalName, username))
                {
                    if (newUser != null)
                    {
                       return newUser.Guid.ToString();
                    }
                }
             }
        }
      return null;
    }
       
