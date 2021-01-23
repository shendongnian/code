    public bool CheckFolderPermissions(string folderPath)
    {
     WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
     var domainAndUser = currentUser.Name;
     DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
     DirectorySecurity dirAC =     dirInfo.GetAccessControl(AccessControlSections.All);
     AuthorizationRuleCollection rules = dirAC.GetAccessRules(true, true, typeof(NTAccount));
     foreach (AuthorizationRule rule in rules)
     {
         if (rule.IdentityReference.Value.Equals(domainAndUser, StringComparison.CurrentCultureIgnoreCase))
         {
             if ((((FileSystemAccessRule)rule).FileSystemRights & FileSystemRights.WriteData) > 0)
             return true;
         }
      }
     return false;
    }
