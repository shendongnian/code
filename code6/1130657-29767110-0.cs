    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Win32.SafeHandles;
    
    namespace UnitTestProject2
    {
        /// <summary>
        /// MVC 5 dosnt support impersonation via web.config for good reasons microsoft decided one day
        /// </summary>
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseHandle(IntPtr handle);
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            internal static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
                int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
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
    
        class Class6
        {
            public void readfile(string filename, string Username, string DomainName, string Password)
            { 
                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token. 
                const int LOGON32_LOGON_INTERACTIVE = 2;
                SafeTokenHandle safeTokenHandle;
    
                // Call LogonUser to obtain a handle to an access token. 
                bool returnValue = NativeMethods.LogonUser(
                    Username, 
                    DomainName, 
                    Password,
                    LOGON32_LOGON_INTERACTIVE, 
                    LOGON32_PROVIDER_DEFAULT,
                    out safeTokenHandle);
    
                if (!returnValue)
                {
                    throw new Exception("unable to login as specifed user :" + Username);
                }
                using (WindowsIdentity id =  new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                using (WindowsImpersonationContext wic = id.Impersonate())
                {
                    if (File.Exists(filename))
                    {
                        //good to go
                    }
                }
            }
        }
    }
