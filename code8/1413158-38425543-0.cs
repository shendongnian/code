    private const int SW_MAXIMIZE = 3;
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private void button1_Click(object sender, EventArgs e)
    {
        var p = System.Diagnostics.Process.GetProcessesByName("WINWORD").FirstOrDefault();
        if(p!=null)
        {
            ShowWindow(p.MainWindowHandle, SW_MAXIMIZE);
        }
    }
