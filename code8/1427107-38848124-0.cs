    using System.Management.Automation;
    // ...
    PowerShell ps = PowerShell.Create();
    ps.AddCommand("Stop-WebAppPool");
    ps.AddArgument("Test1234");
    ps.Invoke();
