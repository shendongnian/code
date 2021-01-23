    var remoteUser = ConfigurationManager.AppSettings["RemoteUser"];
    var remotePassword = ConfigurationManager.AppSettings["RemotePassword"];
    var remoteDomain = ConfigurationManager.AppSettings["RemoteDomain"];
    var safeTokenHandle = ImpersonationHelper.GetSafeTokenHandle(remoteUser, remotePassword, remoteDomain);
    using (safeTokenHandle)
    {
        using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
        {
            using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
            {
                // do stuff here the same as you would locally
            }
        }
     }
