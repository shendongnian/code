    [System.Runtime.InteropServices.DllImport("shell32", EntryPoint = "Control_RunDLLW", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
    private static extern bool Control_RunDLL(IntPtr hwnd, IntPtr hinst, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lpszCmdLine, int nCmdShow);
    private void showOnMainThread_Click(object sender, EventArgs e)
    {
        const int SW_SHOW = 1;
        // this does not work very well, the parent form locks up while the control panel window is open
        Control_RunDLL(this.Handle, IntPtr.Zero, @"telephon.cpl", SW_SHOW);
    }
    private void showOnWorkerThread_Click(object sender, EventArgs e)
    {
        Action hasCompleted = delegate
        {
            MessageBox.Show(this, "Phone and Modem panel has been closed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        };
        Action runAsync = delegate
        {
            const int SW_SHOW = 1;
            Control_RunDLL(IntPtr.Zero, IntPtr.Zero, @"telephon.cpl", SW_SHOW);
            this.BeginInvoke(hasCompleted);
        };
        // the parent form continues to be normally operational while the control panel window is open
        runAsync.BeginInvoke(null, null);
    }
    private void runOutOfProcess_Click(object sender, EventArgs e)
    {
        // the control panel window is hosted in its own process (rundll32)
        System.Diagnostics.Process.Start(@"rundll32.exe", @"shell32,Control_RunDLL telephon.cpl");
    }
