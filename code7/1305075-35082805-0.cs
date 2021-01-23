    // When this method is called for the first time, it creates a table header too.
    // The following is the PowerShell line that will be run in the runspace.
    // Write-Output -InputObject <object_A> | Format-Table | Out-String
    
    // For the next time, when this routine is called, the following gets executed.
    // Write-Output -InputObject <object_A> | Format-Table -HideTableHeaders | Out-String
    
    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    Pipeline pipeLine = runspace.CreatePipeline();
    
    Command command1 = new Command("Write-Output");
    command1.Parameters.Add("InputObject", object_A);
    
    Command command2 = new Command("Format-Table");
    if (this.filePath != null)
    {
        // If this is not the first row, hide the table headers
        command2.Parameters.Add("HideTableHeaders");
    }
    Command command3 = new Command("Out-String");
    
    pipeLine.Commands.Add(command1);
    pipeLine.Commands.Add(command2);
    pipeLine.Commands.Add(command3);
    var results = pipeLine.Invoke();
    
    // The resultant text from the command will have a lot of white spaces/carriage returns.
    // So, let us trim the content before adding it to file.
    foreach (var result in results)
    {
        string data = null;
        data = string.Concat(result);
        data = data.Trim();
    
        // For the first time, we need to create a log file too.
        if (filePath == null)
        {
            // Call custom routine CreateLogFile() which creates a file and returns the file path as string for you
            filePath = CreateLogFile();
        }
    
        // Write the object row into the file.
        using (StreamWriter writer = System.IO.File.AppendText(this.filePath))
        {
            writer.WriteLine(data);
        }
    }
    
    runspace.Close();
