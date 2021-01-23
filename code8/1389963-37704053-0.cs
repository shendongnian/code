    public const int SC_MINIMIZE = 6;
    
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
    static void Main(string[] args)
    {
        Process p = new Process();
        p.StartInfo.FileName = "calc.exe";
        p.Start();
        while (string.IsNullOrEmpty(p.MainWindowTitle))
        {
            Thread.Sleep(50);
            p.Refresh();
        }
        ShowWindow(p.MainWindowHandle, SC_MINIMIZE);
    }
