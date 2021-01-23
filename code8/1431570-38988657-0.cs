    private void winact()
    {
        IntPtr hWnd; //change this to IntPtr
        Process[] processRunning = Process.GetProcesses();
        string title, name;
        foreach (Process pr in processRunning)
        {
            title = pr.MainWindowTitle.ToLower();
            name = pr.ProcessName.ToLower();
            if (title.Contains("teamspeak".ToLower()) || name.Contains("teamspeak".ToLower()))
            {
                hWnd = pr.MainWindowHandle;
                HwndSource hwndSource = HwndSource.FromHwnd(hWnd);
                Window window = hwndSource.RootVisual as Window;
                window.Activate();
                window.TopMost = true;
                ShowWindow(hWnd, 3);
                SetForegroundWindow(hWnd); //set to topmost
                break;
            }
        }
    }
