    Assembly externalAssembly = Assembly.LoadFrom(path);
    // Retrieve the permission set of the external assembly
    PermissionSet permSet = SecurityManager.ResolvePolicy(externalAssembly.Evidence);
    if(!permSet.IsUnrestricted())
    {
        throw new Exception("Assembly is not fully trusted!");
    }
