    private void buttonGO_Click(object sender, EventArgs e)
    {
        // Get all chrome processes
        Process[] chromeProcesses = Process.GetProcessesByName("chrome");
        Process uiProcess = null;
        foreach (Process process in chromeProcesses)
        {
            // Assuming you've opened chrome only once, the UI process will have MainWindowHandle, so get its reference and break out of loop
            if (process.MainWindowHandle != IntPtr.Zero)
            {
                uiProcess = process;
                break;
            }
        }
        if (uiProcess == null)
            return;
        // Do your stuff here
        IntPtr iHandle = uiProcess.MainWindowHandle;
        if (iHandle != IntPtr.Zero)
        {
            SetForegroundWindow(iHandle);
            Thread.Sleep(2000);
            moveToPos(30000, 19500);
            Thread.Sleep(500);
            performClick(30000, 19500);
        }
    }
