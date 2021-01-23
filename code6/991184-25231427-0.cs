    [DllImport("Kernel32")]
    public static extern void AllocConsole();
    
    [DllImport("Kernel32", SetLastError = true)]
    public static extern void FreeConsole();
