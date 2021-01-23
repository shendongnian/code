    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MessageLoop
    {
    	public static class Native
    	{
    		public enum WTS_INFO_CLASS
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
    			WTSClientProtocolType,
    			WTSIdleTime,
    			WTSLogonTime,
    			WTSIncomingBytes,
    			WTSOutgoingBytes,
    			WTSIncomingFrames,
    			WTSOutgoingFrames,
    			WTSClientInfo,
    			WTSSessionInfo
    		}
    
    		[DllImport("wtsapi32.dll", SetLastError = true)]
    		internal static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] int dwFlags);
    
    		[DllImport("wtsapi32.dll", SetLastError = true)]
    		internal static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);
    
    		[DllImport("Wtsapi32.dll")]
    		internal static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out IntPtr ppBuffer, out int pBytesReturned);
    
    		[DllImport("Wtsapi32.dll")]
    		internal static extern void WTSFreeMemory(IntPtr pointer);
    	}
    }
