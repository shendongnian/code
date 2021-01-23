    public ListUsersPS(string searchstring)
    {
    ....
    WindowsIdentity identity = WindowsIdentity.GetCurrent();
    WindowsImpersonationContext ctx = null;
    
    ctx = identity.Impersonate();
    
    Runspaceconfiguration connectionInfo = Runspaceconfiguration.Create();
    ...
    using (Runspace rsp = Runspacefactory.Createrunspace(connectionInfo))
    {
    ...
    }
    ...
    }
