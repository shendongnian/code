    //using System.Security.AccessControl;  
    //using System.Security.Principal;
    
    
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
        if (fs == null)
            return false;
    
        AuthorizationRuleCollection TheseRules = fs.GetAccessRules(true, true, typeof(NTAccount));
        if (TheseRules == null)
            return false;
    
        return CheckACL(TheseRules);
    }
    
    private bool CheckFolderForAccess(string FolderName)
    {
        DirectoryInfo di = new DirectoryInfo(FolderName);
        if (di == null)
            return false;
    
        DirectorySecurity acl = di.GetAccessControl(AccessControlSections.Access);
        if (acl == null)
            return false;
    
        AuthorizationRuleCollection TheseRules = acl.GetAccessRules(true, true, typeof(NTAccount));
        if (TheseRules == null)
            return false;
    
        return CheckACL(TheseRules);
    }
    
    private bool CheckACL(AuthorizationRuleCollection TheseRules)
    {
        foreach (FileSystemAccessRule ThisRule in TheseRules)
        {
            if ((ThisRule.FileSystemRights & FileSystemRights.Read) == FileSystemRights.Read)
            {
                if (ThisRule.AccessControlType == AccessControlType.Deny)
                    return false;
            }
            // Run as many other checks as you like
        }
    
        return true;
    }
