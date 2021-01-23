    var process = new Process();
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    
    process.StartInfo.FileName = Settings.MongoPath;
    
    // Redirects the standard input so that commands can be sent to the shell.
    process.StartInfo.RedirectStandardInput = true;
    
    process.StartInfo.Arguments = ConnString;
                            
    process.Start();
    
    // this is key, this returns 1 once previous command in argument is done executing
    process.StandardInput.WriteLine("{ping:1}");
    
    var current_line = string.Empty;
    var OutputList = new List<string>();
    while (!process.StandardOutput.EndOfStream)
    {
    	current_line = process.StandardOutput.ReadLine();
    	if (current_line == "1")
    	{
    		// command is done executing 
    		break;
    	}
    
    	OutputList.Add(current_line);
    }
    
    // contains all of the out put of the command
    OutputList
