    using System.Security.AccessControl;  
    using System.Security.Principal;
    
    
    private bool CheckForAccess(string PathName)
    {
        // Determine if the path is a file or a directory
    
        if (File.Exists(PathName) == true)
            return CheckFileForAccess(PathName);
    
        if (Directory.Exists(PathName) == true)
            return CheckFolderForAccess(PathName);
    
        return false;
    }
    
    
    private bool CheckFileForAccess(string FileName)
    {
        FileSecurity fs = new FileSecurity(FileName, AccessControlSections.Access);
        AuthorizationRuleCollection acl = fs.GetAccessRules(true, true, typeof(NTAccount));
    
        foreach (FileSystemAccessRule ThisRule in acl)
        {
            if ((ThisRule.FileSystemRights & FileSystemRights.Read) == 0)
            {
                return false;
            }
    
            // Run as many other checks as you like
        }
    
        return true;
    }
    
    private bool CheckFolderForAccess(string FolderName)
    {
        DirectoryInfo di = new DirectoryInfo(FolderName);
        DirectorySecurity acl = di.GetAccessControl(AccessControlSections.Access);
        AuthorizationRuleCollection rules = acl.GetAccessRules(true, true, typeof(NTAccount));
    
        foreach (AuthorizationRule ThisRule in rules)
        {
            FileSystemAccessRule ThisAccessRule = ThisRule as FileSystemAccessRule;
    
            if ((ThisAccessRule.FileSystemRights & FileSystemRights.Read) == 0)
            {
                return false;
            }
    
            // Run as many other checks as you like
        }
    
        return true;
    }
