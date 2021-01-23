     public class WrapperImpersonationContext
        {
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool LogonUser(String lpszUsername, String lpszDomain,
            String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public extern static bool CloseHandle(IntPtr handle);
    
            private const int LOGON32_PROVIDER_DEFAULT = 0;
            private const int LOGON32_LOGON_INTERACTIVE = 2;
    
            private string m_Domain;
            private string m_Password;
            private string m_Username;
            private IntPtr m_Token;
    
            private WindowsImpersonationContext m_Context = null;
    
    
            protected bool IsInContext
            {
                get { return m_Context != null; }
            }
    
            public WrapperImpersonationContext(string domain, string username, string password)
            {
                m_Domain = domain;
                m_Username = username;
                m_Password = password;
            }
    
            [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
            public void Enter(out string result)
            {
                if (this.IsInContext)
                {
                    result = "not in context";
                    return;
                }
                m_Token = new IntPtr(0);
                try
                {
                    m_Token = IntPtr.Zero;
                    bool logonSuccessfull = LogonUser(
                       m_Username,
                       m_Domain,
                       m_Password,
                       LOGON32_LOGON_INTERACTIVE,
                       LOGON32_PROVIDER_DEFAULT,
                       ref m_Token);
                    if (logonSuccessfull == false)
                    {
                        result = "logon failed";
                        int error = Marshal.GetLastWin32Error();
                        throw new Win32Exception(error);
                    }
                    else
                    {
                        result = "logon succseeded";
                    }
                    WindowsIdentity identity = new WindowsIdentity(m_Token);
                    m_Context = identity.Impersonate();
                }
                catch (Exception exception)
                {
                    result = "exception: " + exception.Message;
                    // Catch exceptions here
                }
            }
    
    
            [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
            public void Leave()
            {
                if (this.IsInContext == false) return;
                m_Context.Undo();
    
                if (m_Token != IntPtr.Zero) CloseHandle(m_Token);
                m_Context = null;
            }
        }
