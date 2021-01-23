    foreach (var proc in Process.GetProcesses())
    {
        var procHandle = OpenProcess(ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VirtualMemoryOperation, false, proc.Id);
        if (procHandle == IntPtr.Zero)
        {
            // api call failed, can read error code
            var eCode = Marshal.GetLastWin32Error();
        }
        else
        {
            // api call succeeded, do stuff with handle
            CloseHandle(procHandle);
        }
    }
