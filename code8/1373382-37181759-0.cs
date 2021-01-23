    public void killNotepad()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    //process.ProcessName, process.Id, process.MainWindowTitle);
                    if (process.MainWindowTitle == "Untitled - Notepad")
                    {
                        process.Kill();
                    }
                }
            }
        }
        public void killNotepadRunAsync()
        {
            System.Threading.Thread th = new System.Threading.Thread(() =>
            {
                while (true)
                {
                    killNotepad();
                    System.Threading.Thread.Sleep(300);
                }
            });
            th.SetApartmentState(System.Threading.ApartmentState.STA);
            th.Start();
        }
