        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SwShowmaximized = 3;
        private void Run()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist.Where(process => process.ProcessName == "wfica32"))
            {
                ShowWindow(Process.GetProcessById(process.Id).MainWindowHandle, SwShowmaximized);
            }
        }
