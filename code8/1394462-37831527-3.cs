    using System.DirectoryServices.AccountManagement;
    public static String ChangeUserPassword(String adminName, String adminPassword, String userName, String currentPassword, String newPassword, String domainController, String container)
    {
        try
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController, container, adminName, adminPassword);
            UserPrincipal user = UserPrincipal.FindByIdentity(pc, userName);
            if (user == null)
            {
                return "User name not found in this domain.";
            }
            user.SetPassword(newPassword);
            return "Password for " + userName + "changed successfully.";
        }
        catch (Exception e)
        {
           // throw exception here
           return "An error occurred when trying to connect on LDAP service.";
        }
    }
