        private static void KillExistingProcesses()
        {
            Process myProc = Process.GetCurrentProcess();
            ;
            Process[] p = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            foreach (var pro in p)
            {
                if (pro.Id != myProc.Id)
                {
                    pro.Kill();
                }
            }
        }
