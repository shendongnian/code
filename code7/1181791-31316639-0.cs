    public class ProcessInfo
    {
        public string ProcessName { get; set; }
        public string FileName { get; set; }
    }
    public ProcessInfo GetProcessInfo(IntPtr hwnd)
    {
        uint pid = 0;
        GetWindowThreadProcessId(hwnd, out pid);
        Process proc = Process.GetProcessById((int)pid);
        return new ProcessInfo 
        {
            FileName = proc.MainModule.FileName.ToString(),
            ProcessName = proc.ProcessName
        }
     }
