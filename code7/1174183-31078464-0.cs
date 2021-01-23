    using System.Security.Principal;
    ...
    
    //Get the identity of the current user
    IIdentity contextId = HttpContext.Current.User.Identity;
    WindowsIdentity userId = (WindowsIdentity)contextId;
    
    //Temporarily impersonate
    using (WindowsImpersonationContext imp = userId.Impersonate())
    {
        //Perform tasks using the caller's security context
        DoSecuritySensitiveTasks();
    }
