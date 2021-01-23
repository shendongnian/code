    internal class WtsUtils
    {
        /// <summary>
        /// Contains values that indicate the type of session information to retrieve in a call to the <see cref="WTSQuerySessionInformation"/> function.
        /// </summary>
        private enum WtsInfoClass
        {
            /// <summary>A null-terminated string that contains the name of the initial program that Remote Desktop Services runs when the user logs on.</summary>
            WtsInitialProgram,
            /// <summary>A null-terminated string that contains the published name of the application that the session is running.</summary>
            WtsApplicationName,
            /// <summary>A null-terminated string that contains the default directory used when launching the initial program.</summary>
            WtsWorkingDirectory,
            /// <summary>This value is not used.</summary>
            WtsOemId,
            /// <summary>A <B>ULONG</B> value that contains the session identifier.</summary>
           WtsSessionId,
            /// <summary>A null-terminated string that contains the name of the user associated with the session.</summary>
           WtsUserName,
            /// <summary>A null-terminated string that contains the name of the Remote Desktop Services session.</summary>
            /// <remarks>
            /// <B>Note</B>  Despite its name, specifying this type does not return the window station name.
            /// Rather, it returns the name of the Remote Desktop Services session.
            /// Each Remote Desktop Services session is associated with an interactive window station.
            /// Because the only supported window station name for an interactive window station is "WinSta0",
            /// each session is associated with its own "WinSta0" window station. For more information, see <see href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms687096(v=vs.85).aspx">Window Stations</see>.
            /// </remarks>
            WtsWinStationName,
            /// <summary>A null-terminated string that contains the name of the domain to which the logged-on user belongs.</summary>
            WtsDomainName,
            /// <summary>The session's current connection state. For more information, see WTS_CONNECTSTATE_CLASS.</summary>
            WtsConnectState,
            /// <summary>A <B>ULONG</B> value that contains the build number of the client.</summary>
            WtsClientBuildNumber,
            /// <summary>A null-terminated string that contains the name of the client.</summary>
            WtsClientName,
            /// <summary>A null-terminated string that contains the directory in which the client is installed.</summary>
            WtsClientDirectory,
            /// <summary>A <B>USHORT</B> client-specific product identifier.</summary>
            WtsClientProductId,
            /// <summary>
            /// A <B>ULONG</B> value that contains a client-specific hardware identifier. This option is reserved for future use.
            /// <see cref="WTSQuerySessionInformation" /> will always return a value of 0.
            /// </summary>
            WtsClientHardwareId,
            /// <summary>The network type and network address of the client. For more information, see WTS_CLIENT_ADDRESS.</summary>
            /// <remarks>
            /// The IP address is offset by two bytes from the start of the <B>Address</B> member of the WTS_CLIENT_ADDRESS structure.
            /// </remarks>
            WtsClientAddress,
            /// <summary>Information about the display resolution of the client. For more information, see WTS_CLIENT_DISPLAY.</summary>
            WtsClientDisplay,
            /// <summary>
            /// A USHORT value that specifies information about the protocol type for the session. This is one of the following values:<BR />
            /// 0 - The console session.<BR />
            /// 1 - This value is retained for legacy purposes.<BR />
            /// 2 - The RDP protocol.<BR />
            /// </summary>
            WtsClientProtocolType,
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call Marshal.GetLastError to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks><B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.</remarks>
            WtsIdleTime,
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call GetLastError to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks><B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.</remarks>
            WtsLogonTime,
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call Marshal.GetLastError to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks><B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.</remarks>
            WtsIncomingBytes,
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call Marshal.GetLastError to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks><B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.</remarks>
            WtsOutgoingBytes,
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call Marshal.GetLastError to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks><B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.</remarks>
            WtsIncomingFrames,
            /// <summary>
            /// This value returns <B>FALSE</B>. If you call Marshal.GetLastError to get extended error information, <B>GetLastError</B> returns <B>ERROR_NOT_SUPPORTED</B>.
            /// </summary>
            /// <remarks><B>Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not used.</remarks>
            WtsOutgoingFrames,
            /// <summary>Information about a Remote Desktop Connection (RDC) client. For more information, see WTSCLIENT.</summary>
            /// <remarks>
            /// <B>Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not supported.
            /// This value is supported beginning with Windows Server 2008 and Windows Vista with SP1.
            /// </remarks>
            WtsClientInfo,
            /// <summary>Information about a client session on an RD Session Host server. For more information, see WTSINFO.</summary>
            /// <remarks>
            /// <B>Windows Vista, Windows Server 2003, and Windows XP:</B>  This value is not supported.
            /// This value is supported beginning with Windows Server 2008 and Windows Vista with SP1.
            /// </remarks>
            WtsSessionInfo
        }
        [DllImport("kernel32.dll")]
        private static extern bool ProcessIdToSessionId(uint dwProcessId, out uint sessionId);
        [DllImport("Wtsapi32.dll")]
        private static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WtsInfoClass wtsInfoClass, out IntPtr ppBuffer, out int bytesReturned);
        [DllImport("Wtsapi32.dll")]
        private static extern void WTSFreeMemory(IntPtr pointer);
        public static string GetWindowsSessionUsername()
        {
            uint sessionId;
            ProcessIdToSessionId((uint)Process.GetCurrentProcess().Id, out sessionId);
            return GetUsernameBySessionId((int)sessionId);
        }
        private static string GetUsernameBySessionId(int sessionId)
        {
            IntPtr buffer;
            int strLen;
            string username = "SYSTEM";
            if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WtsInfoClass.WtsUserName, out buffer, out strLen) && strLen > 1)
            {
                username = Marshal.PtrToStringAnsi(buffer);
                WTSFreeMemory(buffer);
            }
            return username;
        }
    }
