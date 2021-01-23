    var permissionSet = new PermissionSet(System.Security.Permissions.PermissionState.None);
    permissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, tempAssemblyPath));
    permissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.PathDiscovery, tempAssemblyPath));
    //The following line fixed the code
    permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution)); 
    
    AppDomain targetAppDomain = AppDomain.CreateDomain("LockedDomain" + Guid.NewGuid().ToString("N"),null,domainSetup,permissionSet,null);
    var instance = (IRemoteFilterClass) targetAppDomain.CreateInstanceFromAndUnwrap(tempAssemblyPath, "CompiledCode.CompiledClass");
