    private void buttonLaunchOSK_Click(object sender, EventArgs e)
    {
        // Launch the OSK.
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + System.IO.Path.DirectorySeparatorChar + "osk.exe");
        // Wait a moment for the OSK window to be created.
        Thread.Sleep(200);
        // Find the OSK window. 
        IntPtr hwndOSK = Form1.FindWindow("OSKMainClass", null);
        // Move and size the OSK window.
        Form1.MoveWindow(hwndOSK, 0, 0, 800, 300, true);
    }
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string className, string windowTitle);
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
