    /// <summary>
    /// Provide a context to impersonate operations.
    /// </summary>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class Impersonate : IDisposable
    {
        /// <summary>
        /// Initialize a new instance of the ImpersonateValidUser class with the specified user name, password, and domain.
        /// </summary>
        /// <param name="userName">The user name associated with the impersonation.</param>
        /// <param name="password">The password for the user name associated with the impersonation.</param>
        /// <param name="domain">The domain associated with the impersonation.</param>
        /// <exception cref="ArgumentException">If the logon operation failed.</exception>
        public Impersonate(string userName, SecureString password, string domain)
        {
            ValidateParameters(userName, password, domain);
            WindowsIdentity tempWindowsIdentity;
            IntPtr userAccountToken = IntPtr.Zero;
            IntPtr passwordPointer = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            try
            {
                if (Kernel32.RevertToSelf())
                {
                    // Marshal the SecureString to unmanaged memory.
                    passwordPointer = Marshal.SecureStringToGlobalAllocUnicode(password);
                    if (Advapi32.LogonUser(userName, domain, passwordPointer, LOGON32_LOGON_INTERACTIVE,
                        LOGON32_PROVIDER_DEFAULT, ref userAccountToken))
                    {
                        if (Advapi32.DuplicateToken(userAccountToken, 2, ref tokenDuplicate) != 0)
                        {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                            impersonationContext = tempWindowsIdentity.Impersonate();
                            if (impersonationContext != null)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            finally
            {
                // Zero-out and free the unmanaged string reference.
                Marshal.ZeroFreeGlobalAllocUnicode(passwordPointer);
                // Close the token handle.
                if (userAccountToken != IntPtr.Zero)
                    Kernel32.CloseHandle(userAccountToken);
                if (tokenDuplicate != IntPtr.Zero)
                    Kernel32.CloseHandle(tokenDuplicate);
            }
            throw new ArgumentException(string.Format("Logon operation failed for userName {0}.", userName));
        }
        /// <summary>
        /// Reverts the user context to the Windows user represented by the WindowsImpersonationContext.
        /// </summary>
        public void UndoImpersonation()
        {
            impersonationContext.Undo();
        }
        /// <summary>
        /// Releases all resources used by <see cref="Impersonate"/> :
        /// - Reverts the user context to the Windows user represented by this object : <see cref="System.Security.Principal.WindowsImpersonationContext"/>.Undo().
        /// - Dispose the <see cref="System.Security.Principal.WindowsImpersonationContext"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (impersonationContext != null)
                {
                    //UndoImpersonation();
                    impersonationContext.Dispose();
                    impersonationContext = null;
                }
            }
        }
        private void ValidateParameters(string userName, SecureString password, string domain)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName");
            }
            if (password == null || password.Length == 0)
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("domain");
            }
        }
        private WindowsImpersonationContext impersonationContext;
        private const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
    }
