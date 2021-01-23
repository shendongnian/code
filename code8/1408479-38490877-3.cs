    public class Impersonation : IDisposable
    {
        private WindowsImpersonationContext _impersonatedUserContext;
        #region FUNCTIONS (P/INVOKE)
        // Declare signatures for Win32 LogonUser and CloseHandle APIs
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool LogonUser(
          string principal,
          string authority,
          string password,
          LogonSessionType logonType,
          LogonProvider logonProvider,
          out IntPtr token);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool RevertToSelf();
        #endregion
        #region ENUMS
        enum LogonSessionType : uint
        {
            Interactive = 2,
            Network,
            Batch,
            Service,
            NetworkCleartext = 8,
            NewCredentials
        }
        
        enum LogonProvider : uint
        {
            Default = 0, // default for platform (use this!)
            WinNT35,     // sends smoke signals to authority
            WinNT40,     // uses NTLM
            WinNT50      // negotiates Kerb or NTLM
        }
        #endregion
        /// <summary>
        /// Class to allow running a segment of code under a given user login context
        /// </summary>
        /// <param name="user">domain\user</param>
        /// <param name="password">user's domain password</param>
        public Impersonation(string domain, string username, string password)
        {
            var token = ValidateParametersAndGetFirstLoginToken(username, domain, password);
            var duplicateToken = IntPtr.Zero;
            try
            {
                if (DuplicateToken(token, 2, ref duplicateToken) == 0)
                {
                    
                    throw new InvalidOperationException("DuplicateToken call to reset permissions for this token failed");
                }
                var identityForLoggedOnUser = new WindowsIdentity(duplicateToken);
                _impersonatedUserContext = identityForLoggedOnUser.Impersonate();
                if (_impersonatedUserContext == null)
                {
                    throw new InvalidOperationException("WindowsIdentity.Impersonate() failed");
                }
            }
            finally
            {
                if (token != IntPtr.Zero)
                    CloseHandle(token);
                if (duplicateToken != IntPtr.Zero)
                    CloseHandle(duplicateToken);
            }
        }
        private static IntPtr ValidateParametersAndGetFirstLoginToken(string domain, string username, string password)
        {
            if (!RevertToSelf())
            {
                ErrorLogger.LogEvent("RevertToSelf call to remove any prior impersonations failed", System.Diagnostics.EventLogEntryType.Error, "");
                throw new InvalidOperationException("RevertToSelf call to remove any prior impersonations failed");
            }
            IntPtr token;
            var result = LogonUser(domain, username,
                                   password,
                                   LogonSessionType.NewCredentials,
                                   LogonProvider.Default,
                                   out token);
            if (!result)
            {
                var errorCode = Marshal.GetLastWin32Error();
                ErrorLogger.LogEvent(string.Format("Could not impersonate the elevated user.  LogonUser: {2}\\{1} returned error code: {0}.", errorCode, username, domain), System.Diagnostics.EventLogEntryType.Error, "");
                throw new InvalidOperationException("Logon for user " + username + " failed.");
            }
            return token;
        }
        public void Dispose()
        {
            // Stop impersonation and revert to the process identity
            if (_impersonatedUserContext != null)
            {
                _impersonatedUserContext.Undo();
                _impersonatedUserContext = null;
            }
        }
    }
