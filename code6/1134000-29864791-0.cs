    using (var powershell = PowerShell.Create())
    using (Runspace runspace = RunspaceFactory.CreateRunspace(connection))
    {
        runspace.Open();
        powershell.Runspace = runspace();
        powershell.AddScript(Command);
        results = powershell.Invoke();
        runspace.Close();
    }
