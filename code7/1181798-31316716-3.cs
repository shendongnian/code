public class ProcessInformation
{
	public string FileName;
	public string ProcessName;
}
public static ProcessInformation GetProcessInfo(IntPtr hwnd)
{
    uint pid = 0;
    GetWindowThreadProcessId(hwnd, out pid);
    Process proc = Process.GetProcessById((int)pid);
    var pi = new ProcessInformation 
	{  
		proc.MainModule.FileName,
		proc.MainModule.ProcessName
	}
	return pi;
}
