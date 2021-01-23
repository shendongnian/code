    #region Console support
    [System.Runtime.InteropServices.DllImport("Kernel32")]
    public static extern void AllocConsole();
    
    [System.Runtime.InteropServices.DllImport("Kernel32")]
    public static extern void FreeConsole();
    #endregion
