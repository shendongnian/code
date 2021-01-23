    public class CreateProcess
    {
        #region Constants
        const UInt32 INFINITE = 0xFFFFFFFF;
        const UInt32 WAIT_FAILED = 0xFFFFFFFF;
        #endregion
        #region ENUMS
        [Flags]
        public enum LogonType
        {
            LOGON32_LOGON_INTERACTIVE = 2,
            LOGON32_LOGON_NETWORK = 3,
            LOGON32_LOGON_BATCH = 4,
            LOGON32_LOGON_SERVICE = 5,
            LOGON32_LOGON_UNLOCK = 7,
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
            LOGON32_LOGON_NEW_CREDENTIALS = 9
        }
        [Flags]
        public enum LogonProvider
        {
            LOGON32_PROVIDER_DEFAULT = 0,
            LOGON32_PROVIDER_WINNT35,
            LOGON32_PROVIDER_WINNT40,
            LOGON32_PROVIDER_WINNT50
        }
        #endregion
        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public String lpReserved;
            public String lpDesktop;
            public String lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 dwProcessId;
            public Int32 dwThreadId;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public unsafe byte* lpSecurityDescriptor;
            public int bInheritHandle;
        }
        public enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }
        #endregion
        #region FUNCTIONS (P/INVOKE)
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool RevertToSelf();
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Boolean LogonUser
        (
            String UserName,
            String Domain,
            String Password,
            LogonType dwLogonType,
            LogonProvider dwLogonProvider,
            out IntPtr phToken
        );
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean CreateProcessAsUser
        (
            IntPtr hToken,
            String lpApplicationName,
            String lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            Boolean bInheritHandles,
            Int32 dwCreationFlags,
            IntPtr lpEnvironment,
            String lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation
        );
     
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject
        (
            IntPtr hHandle,
            UInt32 dwMilliseconds
        );
        [DllImport("kernel32", SetLastError = true)]
        public static extern Boolean CloseHandle(IntPtr handle);
        #endregion
        #region Functions
        public static int LaunchCommand(string command, string domain, string account, string password)
        {
            int ProcessId = -1;
            PROCESS_INFORMATION processInfo = new PROCESS_INFORMATION();
            STARTUPINFO startInfo = new STARTUPINFO();
            Boolean bResult = false;
            UInt32 uiResultWait = WAIT_FAILED;
            var token = ValidateParametersAndGetFirstLoginToken(domain, account, password);
            var duplicateToken = IntPtr.Zero;
            try
            {
                startInfo.cb = Marshal.SizeOf(startInfo);
                //  startInfo.lpDesktop = "winsta0\\default";
                bResult = CreateProcessAsUser(
                    token,
                    null,
                    command,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    false,
                    0,
                    IntPtr.Zero,
                    null,
                    ref startInfo,
                    out processInfo
                );
                if (!bResult) { throw new Exception("CreateProcessAsUser error #" + Marshal.GetLastWin32Error()); }
                // Wait for process to end
                uiResultWait = WaitForSingleObject(processInfo.hProcess, INFINITE);
                ProcessId = processInfo.dwProcessId;
                if (uiResultWait == WAIT_FAILED) { throw new Exception("WaitForSingleObject error #" + Marshal.GetLastWin32Error()); }
            }
            finally
            {
                if (token != IntPtr.Zero)
                    CloseHandle(token);
                if (duplicateToken != IntPtr.Zero)
                    CloseHandle(duplicateToken);
                CloseHandle(processInfo.hProcess);
                CloseHandle(processInfo.hThread);
            }
            return ProcessId;
        }
        private static IntPtr ValidateParametersAndGetFirstLoginToken(string domain, string username, string password)
        {
            if (!RevertToSelf())
            {
                ErrorLogger.LogEvent("RevertToSelf call to remove any prior impersonations failed", System.Diagnostics.EventLogEntryType.Error, "");
                throw new Exception("RevertToSelf call to remove any prior impersonations failed");
            }
            IntPtr token;
            var result = LogonUser(username,
                                   domain,
                                   password,
                                   LogonType.LOGON32_LOGON_INTERACTIVE,
                                   LogonProvider.LOGON32_PROVIDER_DEFAULT,
                                   out token);
            if (!result)
            {
                var errorCode = Marshal.GetLastWin32Error();
                ErrorLogger.LogEvent(string.Format("Could not impersonate the elevated user.  LogonUser: {2}\\{1} returned error code: {0}.", errorCode, username, domain), System.Diagnostics.EventLogEntryType.Error, "");
                throw new Exception("Logon for user " + username + " failed.");
            }
            return token;
        }
        #endregion
    }
