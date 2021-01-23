    // Get full permissons 
    var permission = new FileIOPermission(FileIOPermissionAccess.Write, "Full Physical Path Here");
    var permissionSet = new PermissionSet(PermissionState.None);
    permissionSet.AddPermission(permission);
    if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
    {
          //your code here
    }
