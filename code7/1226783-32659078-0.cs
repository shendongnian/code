    public static class Win32LogonInterop
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static WindowsIdentity LogOn(string domain, string userName, string password)
        {
            IntPtr token = IntPtr.Zero;
            if (NativeMethods.LogonUser(userName, domain, password, ConnectionKind.NewCredentials, Provider.Default, out token))
            {
                return new WindowsIdentity(token);
            }
            else
            {
                RaiseError();
                return null;
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void LogOff(WindowsIdentity identity)
        {
            if (identity != null)
            {
                if (!NativeMethods.CloseHandle(identity.Token))
                    RaiseError();
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private static void RaiseError()
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode);
        }
    }
    internal static class NativeMethods
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUser(
                string userName,
                string domain,
                string password,
                ConnectionKind connectionKind,
                Provider provider,
            out IntPtr token);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr handle);
    }
    public enum Provider
    {
        Default = 0,
        WindowsNT35 = 1,
        WindowsNT40 = 2,
        WindowsNT50 = 3
    }
    public enum SecurityLevel
    {
        Anonymous = 0,
        Identification = 1,
        Impersonation = 2,
        Delegation = 3
    }
    public enum ConnectionKind
    {
        Unknown = 0,
        Interactive = 2,
        Network = 3,
        Batch = 4,
        Service = 5,
        Unlock = 7,
        NetworkClearText = 8,
        NewCredentials = 9
    }
