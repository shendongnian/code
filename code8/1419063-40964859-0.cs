    using System.Runtime.InteropServices;
    
    [DllImport("wtsapi32.dll", SetLastError = true)]
    public static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);
    
    WTSDisconnectSession(IntPtr.Zero, 1, false);
