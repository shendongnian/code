    foreach (var proc in Process.GetProcesses())
    {
        var procHandle = OpenProcess(ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VirtualMemoryOperation, false, proc.Id);
        if (procHandle != IntPtr.Zero)
        {
            var eCode = Marshal.GetLastWin32Error();
        }
        else
        {
            CloseHandle(procHandle);
        }
    }
