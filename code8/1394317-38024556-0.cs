    Collection<PSObject> results;
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo() { ComputerName = "COMPUTER" };
    using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
    {
        runspace.Open();
        using (PowerShell ps = PowerShell.Create())
        {
            ps.Runspace = runspace;
            ps.AddScript("something to run");
            results = ps.Invoke();
            if(ps.HadErrors)
            {
                //Throw or log if you want
                //ps.Streams.Error.ElementAt(0).Exception;
            }
        }
        runspace.Close();
    }
