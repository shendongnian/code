    using System.DirectoryServices.AccountManagement;
    public static string[] GetGroups(string username)
    {
        string[] output = null;
        using (var ctx = new PrincipalContext(ContextType.Domain))
        using (var user = UserPrincipal.FindByIdentity(ctx, username))
        {
            if (user != null)
            {
                output = user.GetGroups() //this returns a collection of principal objects
                    .Select(x => x.SamAccountName) // select the name.  you may change this to choose the display name or whatever you want
                    .ToArray(); // convert to string array
            }
        }
        return output;
    }
