    InitialSessionState initial = InitialSessionState.CreateDefault();
    initial.ImportPSModule(new[] {"SmbShare"} );
    Runspace runspace = RunspaceFactory.CreateRunspace(initial);
    runspace.Open();     
    PowerShell ps = PowerShell.Create();
    ps.Runspace = runspace;
