public static Tuple<string, string> GetProcessInfo(IntPtr hwnd)
{
    uint pid = 0;
    GetWindowThreadProcessId(hwnd, out pid);
    Process proc = Process.GetProcessById((int)pid);
    return return Tuple.Create(proc.MainModule.FileName,proc.MainModule.ProcessName);;
}
