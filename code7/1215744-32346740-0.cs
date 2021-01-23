    private string BatchCommand(string cmd, string mapD)
        {
            
            
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmd);
            procStartInfo.WorkingDirectory = mapD;
            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process cmdProcess = new System.Diagnostics.Process();
            cmdProcess.StartInfo = procStartInfo;
            cmdProcess.ErrorDataReceived += cmd_Error;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.StandardInput.WriteLine("ping www.google.com");     //Execute ping
            cmdProcess.StandardInput.WriteLine("exit");                  //Execute exit.
            cmdProcess.WaitForExit();
            // Get the output into a string
            return Batchresults;
        }
        static void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Batchresults += Environment.NewLine + e.Data.ToString();
        }
         void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Batchresults += Environment.NewLine + e.Data.ToString();
                
            }
        }
