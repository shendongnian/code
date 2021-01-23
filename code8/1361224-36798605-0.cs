        // create Powershell runspace
        Runspace runspace = RunspaceFactory.CreateRunspace();
        // open it
        runspace.Open();
        // create a pipeline and feed it the script text
        Pipeline pipeline = runspace.CreatePipeline();
        //Getting all command variables
        string computerName = "YourComputerName";
        string matchingPattern = "con";
        //Create Script command
        String customScriptText = String.Format("Get-Process -ComputerName {0} | Where-Object {{$_.ProcessName -match \"{1}\"}}", computerName,matchingPattern);
        pipeline.Commands.AddScript(customScriptText);
        // add an extra command to transform the script output objects into nicely formatted strings
        // remove this line to get the actual objects that the script returns.
        pipeline.Commands.Add("Out-String");
        // execute the script
        Collection<PSObject> results = pipeline.Invoke();
        // close the runspace
        runspace.Close();
        // convert the script result into a single string
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PSObject obj in results)
        {
            stringBuilder.AppendLine(obj.ToString());
        }
