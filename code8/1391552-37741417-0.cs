    private void LookProcess(string processName, string newProcessPath)
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.ProcessName == processName)
                    {
                        ProcessStartInfo prcinf = new ProcessStartInfo();
                        prcinf.WindowStyle = ProcessWindowStyle.Maximized;
                        prcinf.FileName = newProcessPath;
    
                        Process.Start(prcinfprc);
                    }
                }
            }
