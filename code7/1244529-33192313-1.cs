    // obtains user token
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
        int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    // closes open handes returned by LogonUser
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public extern static bool CloseHandle(IntPtr handle);
    public void DoWorkUnderImpersonation() {
        //elevate privileges before doing file copy to handle domain security
        WindowsImpersonationContext impersonationContext = null;
        IntPtr userHandle = IntPtr.Zero;
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_LOGON_INTERACTIVE = 2;
        string domain = ConfigurationManager.AppSettings["ImpersonationDomain"];
        string user = ConfigurationManager.AppSettings["ImpersonationUser"];
        string password = ConfigurationManager.AppSettings["ImpersonationPassword"];
        try {
            Console.WriteLine("windows identify before impersonation: " + WindowsIdentity.GetCurrent().Name);
            // if domain name was blank, assume local machine
            if (domain == "")
                domain = System.Environment.MachineName;
            // Call LogonUser to get a token for the user
            bool loggedOn = LogonUser(user,
                                        domain,
                                        password,
                                        LOGON32_LOGON_INTERACTIVE,
                                        LOGON32_PROVIDER_DEFAULT,
                                        ref userHandle);
            if (!loggedOn) {
                Console.WriteLine("Exception impersonating user, error code: " + Marshal.GetLastWin32Error());
                return;
            }
            // Begin impersonating the user
            impersonationContext = WindowsIdentity.Impersonate(userHandle);
            Console.WriteLine("Main() windows identify after impersonation: " + WindowsIdentity.GetCurrent().Name);
            //run the program with elevated privileges (like file copying from a domain server)
            DoWork();
        } catch (Exception ex) {
            Console.WriteLine("Exception impersonating user: " + ex.Message);
        } finally {
            // Clean up
            if (impersonationContext != null) {
                impersonationContext.Undo();
            }
            if (userHandle != IntPtr.Zero) {
                CloseHandle(userHandle);
            }
        }
    }
    private void DoWork() {
        //everything in here has elevated privileges
        X509Certificate2 certificate = new X509Certificate2("C:\\teste\\cert.pfx", "password");
        X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadWrite);
        store.Add(certificate);
        store.Close();
    }
