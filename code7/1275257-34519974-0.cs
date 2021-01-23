    public string RunScript(string script)
    {
        string tempOut = "";
        try
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript(script);
                ps.AddCommand("Out-String");
                ps.Commands.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
                List<PSObject> psOutputs = ps.Invoke().ToList();
                foreach (PSObject psObject in psOutputs)
                {
                    if (psObject != null)
                    {
                        tempOut += psObject.BaseObject;
                    }
                }
            }
        }
        catch(Exception ex)
        {
            tempOut = string.Format("Error when invoking powershell commands:\n{0}", ex.Message);
            tempOut += "\nThis function did not complete.";
        }
        return tempOut;
    }
