public static ProcessModule GetProcessInfo(IntPtr hwnd)
{
    uint pid = 0;
    GetWindowThreadProcessId(hwnd, out pid);
    Process proc = Process.GetProcessById((int)pid);
    return proc.MainModule;
}
