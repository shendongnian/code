    using System.Security.Principal;
    WindowsIdentity impersonatedUser = WindowsIdentity.GetCurrent();
    
    // Kick off the actual, private long-running process in a new Task
    task = Task.Factory.StartNew(() =>
    {
        using(WindowsImpersonationContext ctx = impersonatedUser.Impersonate())
        {
            CommitToDb();
        }
    });
