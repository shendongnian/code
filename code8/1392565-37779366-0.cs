    private RunspacePool rsPool;
    public void ProcessFiles(string[] files)
    {
        // Set up InitialSessionState 
        InitialSessionState initState = InitialSessionState.Create();
        initState.ImportPSModule(new string[] { "MyModule" });
        initState.LanguageMode = PSLanguageMode.FullLanguage;
        // Set up the RunspacePool
        rsPool = RunspaceFactory.CreateRunspacePool(initialSessionState: initState);
        rsPool.SetMinRunspaces(1);
        rsPool.SetMaxRunspaces(8);
        rsPool.Open();
        // Run ForEach()
        Parallel.ForEach(files, ProcessFile);
    }
    private void ProcessFile(string filepath)
    {
        // Start PS Session and Process file
        using (PowerShell PowerShellInstance = PowerShell.Create())
        {
            // Assign the instance to the RunspacePool
            PowerShellInstance.RunspacePool = rsPool;
            
            // Run your script, MyModule has already been imported
            PowerShellInstance.AddScript("param($path) Process-File @PSBoundParameters").AddParameter("path", filepath);
            PowerShellInstance.Invoke();
        }
    }
