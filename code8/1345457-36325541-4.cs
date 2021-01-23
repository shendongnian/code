    System.Diagnostics.Process process = null;
    
       void runCommand(string commandFileName, string arg)
        {
            //Debug.Log("Full command: " + arg);
            process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    
            //No Windows
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false; //Optional
    
            //Redirect to get response
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.FileName = commandFileName;
            startInfo.Arguments = arg;
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += _StreamerProcess_OutputDataReceived;
            process.ErrorDataReceived += _StreamerProcess_ErrorDataReceived;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }
