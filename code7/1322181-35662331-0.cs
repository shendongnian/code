    static void byProcess()
        {
            Process[] processes = Process.GetProcesses();
            List<string> suspendedAppsWhichHasTitle = new List<string>();
            foreach (var proc in processes)
            {
                // if it has main window title
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    // the app may be in suspend state 
                    foreach (ProcessThread pT in proc.Threads)
                    {
                        ThreadState ts = pT.ThreadState;
                        if (ts == ThreadState.Running)
                        {
                            suspendedAppsWhichHasTitle.Add(proc.MainWindowTitle);
                        }
                    }                    
                }
            }
            foreach(string app in suspendedAppsWhichHasTitle)
            {
                Console.WriteLine(app);
            }
            if (suspendedAppsWhichHasTitle.Count == 0)
            {
                Console.WriteLine("No visible app is running!");
            }
            Console.Read();
        }
}
