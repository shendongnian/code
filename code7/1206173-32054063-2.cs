        static void Main(string[] args)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ping.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string output_error = proc.StandardError.ReadToEnd();
            string output_stan = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            Trace.TraceInformation(output_stan);
        }
