     [DllImport("user32.dll")]
    static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(int hWnd);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int GetWindowText(int hWnd, StringBuilder title, int size);
    delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
    public List<IntPtr> GetMainWindowHandle()
    {
        var list = Process.GetProcessesByName(ProcessName);
        List<IntPtr> windowList = new List<IntPtr>();
        foreach (Process process in list)
        {
            if (process.MainWindowHandle != IntPtr.Zero)
            //windowList.Add(ThisProcess.MainWindowHandle);
            {
                foreach (ProcessThread processThread in process.Threads)
                {
                    EnumThreadWindows(processThread.Id,
                     (hWnd, lParam) =>
                     {
                         //Check if Window is Visible or not.
                         if (!IsWindowVisible((int)hWnd))
                             return true;
                         //Get the Window's Title.
                         StringBuilder title = new StringBuilder(256);
                         GetWindowText((int)hWnd, title, 256);
                         //Check if Window has Title.
                         if (title.Length == 0)
                             return true;
                         windowList.Add(hWnd);
                         return true;
                     }, IntPtr.Zero);
                }
            }
        }
        return windowList;
    }
