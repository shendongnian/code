     static void Main(string[] args)
            {
                Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                p.StartInfo.Verb = "runas";
                p.StartInfo.FileName =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Defrag.exe");
    
                p.StartInfo.Arguments = @"c:\ /A";
    
                // Additional properties set
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
        
                // Fixed your request for standard with ReadToEnd
                string result = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
