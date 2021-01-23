        // using System.Diagnostics;
        // using System.Threading;
        // using System.IO
        private ManualResetEvent mre;
        private void button_Click(object sender, EventArgs e)
        {
            mre = new ManualResetEvent(false);
            Debug.WriteLine("Beginn");
            FileInfo executable = new FileInfo(@"C:\Temp\cmd.bat");
            ProcessStartInfo startInfo = new ProcessStartInfo(executable.FullName);
            startInfo.Arguments = "two arguments";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = startInfo;
            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            process.Exited += new EventHandler(process_Exited);
            Debug.WriteLine(String.Format("Starting external Application: {0}", executable.FullName));
            process.Start();
            process.BeginOutputReadLine();
            mre.WaitOne();
            Debug.WriteLine("End");
        }
        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine(e.Data);
        }
        void process_Exited(object sender, EventArgs e)
        {
            Debug.WriteLine("Finished executing external Application");
            mre.Set();
        }
