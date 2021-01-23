    using System;
    using System.Runtime.InteropServices;
    
    public class LockWorkstation
    {
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);
    
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern int WTSEnumerateSessions(IntPtr hServer, int Reserved, int Version, ref IntPtr ppSessionInfo, ref int pCount);
    
        [DllImport("wtsapi32.dll")]
        static extern void WTSFreeMemory(IntPtr pMemory);
    
        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public Int32 SessionID;
    
            [MarshalAs(UnmanagedType.LPStr)]
            public String pWinStationName;
    
            public WTS_CONNECTSTATE_CLASS State;
        }
    
        private enum WTS_INFO_CLASS
        {
            WTSInitialProgram,
            WTSApplicationName,
            WTSWorkingDirectory,
            WTSOEMId,
            WTSSessionId,
            WTSUserName,
            WTSWinStationName,
            WTSDomainName,
            WTSConnectState,
            WTSClientBuildNumber,
            WTSClientName,
            WTSClientDirectory,
            WTSClientProductId,
            WTSClientHardwareId,
            WTSClientAddress,
            WTSClientDisplay,
            WTSClientProtocolType
        }
    
        private enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        }
    
        public static void LockWorkStation()
        {
            IntPtr ppSessionInfo = IntPtr.Zero;
            Int32 count = 0;
            Int32 retval = WTSEnumerateSessions(IntPtr.Zero, 0, 1, ref ppSessionInfo, ref count);
            Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
            Int32 currentSession = (int)ppSessionInfo;
    
            if (retval == 0) return;
    
            for (int i = 0; i < count; i++)
            {
                WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure((System.IntPtr)currentSession, typeof(WTS_SESSION_INFO));
                if (si.State == WTS_CONNECTSTATE_CLASS.WTSActive) WTSDisconnectSession(IntPtr.Zero, si.SessionID, false);
                currentSession += dataSize;
            }
            WTSFreeMemory(ppSessionInfo);
        }
    }
