    System.Diagnostics.Process process = null;
    
       void runCommand(string commandFileName, string arg)
        {
            //Debug.Log("Full command: " + arg);
            process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    
            //No Windows
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false; //
    
            //Redirect to get response
            startInfo.RedirectStandardOutput = true;
    
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = commandFileName;
            //startInfo.Arguments = "/C " + arg; // /C to auto exit without waiting for the user to press something
            startInfo.Arguments = arg;
            process.StartInfo = startInfo;
            process.Start();
        }
