    class Program
        {
            static void Main(string[] args)
            {
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.FileName = "git.exe";
                pInfo.Arguments = "diff --name-only --exit-code V2.4-Beta-01 HEAD";
                pInfo.WorkingDirectory = @"C:\Git";
                pInfo.UseShellExecute = false;
                pInfo.CreateNoWindow = true;
                pInfo.RedirectStandardError = true;
                pInfo.RedirectStandardOutput = true;
    
                string output = string.Empty;
    
                Process p = new Process();
                p.StartInfo = pInfo;
    
                p.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        output += e.Data + Environment.NewLine;
                    }
                });
    
                p.Start();
    
                p.BeginOutputReadLine();
    
                p.WaitForExit();
                p.Close();
    
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
