    var writePermissionSet = new PermissionSet(PermissionState.None);
    writePermissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.Write, path));
    if (!Properties.Settings.Default.searchReadOnly &&
        !writePermissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
        //diPath.Attributes.HasFlag(FileAttributes.ReadOnly))
        searchable = false;
