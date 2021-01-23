    void ExecutePowerShellUsingRemotimg()
    {
        RunspaceConfiguration runspaceConfig = RunspaceConfiguration.Create();
        PSSnapInException snapInException = null;
    
        Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfig);
        runspace.Open();
    
        Pipeline pipeline = runspace.CreatePipeline();
    
    
        string serverFqdn = "FQDN of you server";
        pipeline.Commands.AddScript(string.Format("$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri http://{0}/PowerShell/ -Authentication Kerberos", serverFqdn));
        pipeline.Commands.AddScript("Import-PSSession $Session");
        pipeline.Commands.AddScript("your PowerShell script text");
        pipeline.Commands.Add("Out-String");
        Collection<PSObject> results = pipeline.Invoke();
        runspace.Close();
    
        StringBuilder sb = new StringBuilder();
    
        if (pipeline.Error != null && pipeline.Error.Count > 0)
        {
            // Read errors
            succeeded = false;
            Collection<object> errors = pipeline.Error.ReadToEnd();
            foreach (object error in errors)
                sb.Append(error.ToString());
        }
        else
        {
            // Read output
            foreach (PSObject obj in results)
                sb.Append(obj.ToString());
        }
    
        runspace.Dispose();
        pipeline.Dispose();
    }
            
