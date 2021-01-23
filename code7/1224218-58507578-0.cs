    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(
         ProcessAccessFlags processAccess,
         bool bInheritHandle,
         int processId
    );
    public static IntPtr OpenProcess(Process proc, ProcessAccessFlags flags)
    {
         return OpenProcess(flags, false, proc.Id);
    }
    [Flags]
    public enum ProcessAccessFlags : uint
    {
        All = 0x001F0FFF,
        Terminate = 0x00000001,
        CreateThread = 0x00000002,
        VirtualMemoryOperation = 0x00000008,
        VirtualMemoryRead = 0x00000010,
        VirtualMemoryWrite = 0x00000020,
        DuplicateHandle = 0x00000040,
        CreateProcess = 0x000000080,
        SetQuota = 0x00000100,
        SetInformation = 0x00000200,
        QueryInformation = 0x00000400,
        QueryLimitedInformation = 0x00001000,
        Synchronize = 0x00100000
    }
    [DllImport("kernel32.dll", SetLastError = true)]
      public static extern bool WriteProcessMemory(
      IntPtr hProcess,
      IntPtr lpBaseAddress,
      byte[] lpBuffer,
      Int32 nSize,
      out IntPtr lpNumberOfBytesWritten);
    
    [DllImport("kernel32.dll", SetLastError = true)]
      public static extern bool WriteProcessMemory(
      IntPtr hProcess,
      IntPtr lpBaseAddress,
      [MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
      int dwSize,
      out IntPtr lpNumberOfBytesWritten);
