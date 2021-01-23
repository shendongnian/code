        private void KillProcess(string _process)
        {
            Process[] procs = Process.GetProcesses();
            foreach (Process proc in procs)
            {
                if (proc.ProcessName == _process)
                {
                    proc.Kill();
                    proc.WaitForExit();
                }
            }
        }
