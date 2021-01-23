    PowerShell ps = PowerShell.Create();
    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    ps.Runspace = runspace;
    ps.AddCommand("Invoke-Expression");
    ps.AddArgument("netsh interface set interface \"Wi-Fi\" admin=enable");
    // if you need the result save it in a psobject
    Collection<PSObject> result =  ps.Invoke();
    runspace.Close();
