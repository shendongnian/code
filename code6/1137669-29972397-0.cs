    public class Impersonator
    {
        public WindowsImpersonationContext Impersonate(string username, string domain, string password)
        {
            WindowsIdentity tempWindowsIdentity;
            const int LOGON32_PROVIDER_DEFAULT = 0;
            //This parameter causes LogonUser to create a primary token. 
            const int LOGON32_LOGON_INTERACTIVE = 2;
            SafeTokenHandle token;
            IntPtr tokenDuplicate = IntPtr.Zero;
    
            if (NativeMethods.RevertToSelf())
            {
                // Call LogonUser to obtain a handle to an access token. 
                bool returnValue = NativeMethods.LogonUser(
                    username,
                    domain,
                    password,
                    LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT,
                    out token);
    
                if (returnValue)
                {
                    if (NativeMethods.DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        NativeMethods.CloseHandle(tokenDuplicate);
                        return tempWindowsIdentity.Impersonate();
                    }
                    else
                    {
                        throw new Exception("unable to login as specifed user - duplicate ");
                    }
                }
                else
                {
                    throw new Exception("unable to login as specifed user ");
                }
            }
            else
            {
                throw new Exception("could not revert to self ");
            }
            using (WindowsIdentity id = new WindowsIdentity(token.DangerousGetHandle()))
            {
                return id.Impersonate();
            }
        }
    }
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr handle);
    
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool LogonUser(
            String lpszUsername, 
            String lpszDomain, 
            String lpszPassword,
            int dwLogonType, 
            int dwLogonProvider, 
            out SafeTokenHandle phToken);
    
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(
            SafeTokenHandle hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);
    
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();
    }
    
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }
    
        protected override bool ReleaseHandle()
        {
            return NativeMethods.CloseHandle(handle);
        }
    }
