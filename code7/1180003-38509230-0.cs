    var command = "ln source dest"; 
    
    var proc = new System.Diagnostics.Process ();
    proc.StartInfo.FileName = "/bin/bash";
    proc.StartInfo.Arguments = "-c \"" + command + "\"";
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.Start ();
    
    while (!proc.StandardOutput.EndOfStream) {
        string line = proc.StandardOutput.ReadLine ();
    
        // In case you need output do stuff in here
    }
