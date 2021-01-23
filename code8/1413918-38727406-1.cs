    try
    {
        TokenManipulator.AddPrivilege("SeRestorePrivilege");
        TokenManipulator.AddPrivilege("SeBackupPrivilege");
        TokenManipulator.AddPrivilege("SeTakeOwnershipPrivilege");
        
        var subKey = Registry.ClassesRoot.OpenSubKey(@"AppID\{9CA88EE3-ACB7-47c8-AFC4-AB702511C276}", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.TakeOwnership);
        // code to change owner...
    }
    finally
    {
        TokenManipulator.RemovePrivilege("SeRestorePrivilege");
        TokenManipulator.RemovePrivilege("SeBackupPrivilege");
        TokenManipulator.RemovePrivilege("SeTakeOwnershipPrivilege");
    }
