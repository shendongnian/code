    var startInfo = new ProcessStartInfo {
        FileName = <Your Application>,
    	UseShellExecute = false, // Required to use RedirectStandardOutput
    	RedirectStandardOutput = true, //Required to be able to read StandardOutput
    	Arguments = <Args> // Skip this if you don't use Arguments
    };
    
    using(var process = new Process { StartInfo = startInfo })
    {
    	process.Start();
    
        process.OutputDataReceived += (sender, line) =>
        {
            if (line.Data != null)
                Console.WriteLine(line.Data);
        };
        
        process.BeginOutputReadLine();
        
        process.WaitForExit();
    }
