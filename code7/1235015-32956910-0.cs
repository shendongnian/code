    public bool IsPingable(string servA, string servB)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Resources\\PsExec.exe";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = @"\\" + servA + " ping " + servB + " -n 1";
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            if (!output.Contains("100% loss"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
