    using System.IO;
    using System.Security.AccessControl;
    public static FileSystemRights GetDirectoryPermissions(string user, string domainName, string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            return (0);
        }
    
        string identityReference = ((domainName + @"\" + user) as string).ToLower();
        DirectorySecurity dirSecurity = Directory.GetAccessControl(folderPath, AccessControlSections.Access);
        foreach (FileSystemAccessRule fsRule in dirSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
        {
            if (fsRule.IdentityReference.Value.ToLower() == identityReference)
            {
                return (fsRule.FileSystemRights);
            }
        }
        return (0);
    }
