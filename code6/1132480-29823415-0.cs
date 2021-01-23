        void Run(string yourprog, string yourargs)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = yourprog;
            proc.StartInfo.Arguments = yourargs;
            proc.StartInfo.UseShellExecute = false;
            proc.ErrorDataReceived += proc_ErrorDataReceived;
            proc.OutputDataReceived += proc_OutputDataReceived;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.EnableRaisingEvents = true;
            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            
        }
        object lock = new object();
        void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            lock (lock)
            {
                Console.WriteLine("STDOUT: {0}", e.Data);
            }
        }
        void proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            lock (lock)
            {
                Console.WriteLine("STDERR: {0}", e.Data);
            }
        }
