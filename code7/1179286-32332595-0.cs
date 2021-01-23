    foreach (Process p in Process.GetProcesses())
    {
        if (p.MainWindowHandle != IntPtr.Zero)
        {
            if (IsIconic(p.MainWindowHandle))
            {
                System.Diagnostics.Debug.Print("Window: {0} Is minimized", p.MainWindowTitle);
            }
        }
    }
