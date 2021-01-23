            var proc = new Process();
            proc.StartInfo.FileName = @"C:\\ConsoleApplication1";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.OutputDataReceived += Proc_OutputDataReceived;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            private static void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine(e.Data);
            }
