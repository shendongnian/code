    private void ParallelCloseWindows()
    {
        while (!stopClosingWindows)
        {
            // Only look every 200ms so we don't waste processor ressources
            Thread.Sleep(200);
            // perform the task
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.MainWindowTitle == "Untitled - Notepad")
                    {
                        process.Kill();
                    }
                }
            }
        }
    }
