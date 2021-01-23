    FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, this.GetFileServerRootPath);
    
    try
    
        {
            writePermission.Demand();
            return true;
        }
        catch (SecurityException s)
        {
            return false;
        }
