    PowerShell ps = PowerShell.Create();
    Runspace runspace = RunspaceFactory.CreateRunspace();
    ps.Runspace = runspace;
    ps.Runspace.Open();
    using (var impersonationContext = ((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate())
    {
        //...Code
    }
