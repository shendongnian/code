    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public class OnlyOneWindow
    {
        [DllImport("user32.dll")] private static extern 
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")] private static extern 
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")] private static extern 
            bool IsIconic(IntPtr hWnd);
    
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
    
        public OnlyOneWindow()
        {
            // get the name of our process
            string proc=Process.GetCurrentProcess().ProcessName;
            // get the list of all processes by that name
            Process[] processes=Process.GetProcessesByName(proc);
            // if there is more than one process...
            if (processes.Length > 1)
            {
                // Assume there is our process, which we will terminate, 
                // and the other process, which we want to bring to the 
                // foreground. This assumes there are only two processes 
                // in the processes array, and we need to find out which 
                // one is NOT us.
    
                // get our process
                Process p=Process.GetCurrentProcess();
                int n=0;        // assume the other process is at index 0
                // if this process id is OUR process ID...
                if (processes[0].Id==p.Id)
                {
                    // then the other process is at index 1
                    n=1;
                }
                // get the window handle
                IntPtr hWnd=processes[n].MainWindowHandle;
                // if iconic, we need to restore the window
                if (IsIconic(hWnd))
                {
                    ShowWindowAsync(hWnd, SW_RESTORE);
                }
                // bring it to the foreground
                SetForegroundWindow(hWnd);
                // exit our process
                return;
            }
            // ... continue with your application initialization here.
        }
    }
