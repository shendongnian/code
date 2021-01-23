    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Linq;
    using System.Text;
    namespace TopSekrit
    {
    public class UserImpersonator
    {
        #region Imports
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private unsafe static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, int dwMessageId, int dwLanguageId, ref String lpBuffer, int nSize, IntPtr* arguments);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr existingTokenHandle, int SECURITY_IMPERSONATION_LEVEL, ref IntPtr duplicateTokenHandle);
        #endregion
        #region Constants
        // Logon Types as defined in Winbase.h
        const int LOGON32_LOGON_INTERACTIVE = 2;
        const int LOGON32_LOGON_NETWORK = 3;
        const int LOGON32_LOGON_BATCH = 4;
        const int LOGON32_LOGON_SERVICE = 5;
        const int LOGON32_LOGON_UNKNOWN = 6;
        const int LOGON32_LOGON_UNLOCK = 7;
        const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;
        const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
        // Logon Providers as defined in Winbase.h
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_PROVIDER_WINNT35 = 1;
        const int LOGON32_PROVIDER_WINNT40 = 2;
        const int LOGON32_PROVIDER_WINNT50 = 3;
        #endregion
        #region Properties
        protected String _Username = String.Empty;
        public String Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                this._Username = value;
            }
        }
        protected String _Password = String.Empty;
        public String Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }
        protected String _Domain = String.Empty;
        public String Domain
        {
            get
            {
                return this._Domain;
            }
            set
            {
                this._Domain = value;
            }
        }
        protected System.Delegate _Method = null;
        public System.Delegate Method
        {
            get
            {
                return this._Method;
            }
            set
            {
                this._Method = value;
            }
        }                                                               
        protected IntPtr PrimaryToken = IntPtr.Zero;
        protected IntPtr MutatedToken = IntPtr.Zero;
        protected WindowsIdentity _TargetIdentity = null;
        public WindowsIdentity TargetIdentity
        {
            get
            {
                return this._TargetIdentity;
            }
        }
        protected WindowsImpersonationContext _ImpersonationContext = null;
        public WindowsImpersonationContext ImpersonationContext
        {
            get
            {
                return this._ImpersonationContext;
            }
        }
        protected Boolean _Executing = false;
        public Boolean Executing
        {
            get
            {
                return this._Executing;
            }
        }
        #endregion
        #region Constructors
        public UserImpersonator(String Username,String Password,String Domain,System.Delegate Method)
        {
            if (String.IsNullOrEmpty(Username))
                throw new ArgumentNullException();
            else
            {
                this.Username = Username;
                this.Password = Password;
                this.Domain = Domain;
                this.Method = Method;
                return;
            }
        }
        public UserImpersonator(String Username, String Password, String Domain)
            :this( Username, Password, Domain, null)
        {
        }
        #endregion
        #region Impersonated Execution
        public Object Execute()
        {
            if (this.Method == null)
                throw new InvalidOperationException();
            else if (!this.Open())
                throw new InvalidOperationException("Could not open security context.");
            else
            {
                try
                {
                    this._Executing = true;
                    Object ReturnValue = this.Method.DynamicInvoke();
                    this.Close();
                    this._Executing = false;
                    return ReturnValue;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public Object Execute(params object[] Arguments)
        {
            if (this.Method == null)
                throw new InvalidOperationException();
            else if (!this.Open())
                throw new InvalidOperationException("Could not open security context.");
            else
            {
                try
                {
                    this._Executing = true;
                    Object ReturnValue = this.Method.DynamicInvoke(Arguments);
                    this.Close();
                    this._Executing = false;
                    return ReturnValue;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public Object Execute(System.Delegate Method)
        {
            if (Method == null)
                throw new InvalidOperationException();
            else if (!this.Open())
                throw new InvalidOperationException("Could not open security context.");
            else
            {
                try
                {
                    this._Executing = true;
                    Object ReturnValue = Method.DynamicInvoke();
                    this.Close();
                    this._Executing = false;
                    return ReturnValue;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public Object Execute(System.Delegate Method, params object[] Arguments)
        {
            if (Method == null)
                throw new InvalidOperationException();
            else if (!this.Open())
                throw new InvalidOperationException("Could not open security context.");
            else
            {
                try
                {
                    this._Executing = true;
                    Object ReturnValue = Method.DynamicInvoke(Arguments);
                    this.Close();
                    this._Executing = false;
                    return ReturnValue;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        #endregion
        #region Impersonation / Depersonation
        public Boolean Open()
        {
            if (!LogonUser(this.Username, this.Domain, this.Password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref this.PrimaryToken))
            {
                RaiseLastError();
                return false;
            }
            else if (!DuplicateToken(this.PrimaryToken, 2, ref this.MutatedToken))
            {
                RaiseLastError();
                return false;
            }
            else
            {
                try
                {
                    this._TargetIdentity = new WindowsIdentity(this.MutatedToken);
                    this._ImpersonationContext = this._TargetIdentity.Impersonate();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public void Close()
        {
            if( this._ImpersonationContext != null )
                this._ImpersonationContext.Undo();
            if( this.PrimaryToken != null )
                if (!CloseHandle(this.PrimaryToken))
                    RaiseLastError();
        }
        #endregion
        #region Error Handling
        private static void RaiseLastError()
        {
            int ErrorCode = Marshal.GetLastWin32Error();
            string ErrorMessage = GetErrorMessage(ErrorCode);
            throw new ApplicationException(ErrorMessage);
        }
        public unsafe static string GetErrorMessage(int errorCode)
        {
            int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
            int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
            int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
            int messageSize = 255;
            string lpMsgBuf = "";
            int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;
            IntPtr ptrlpSource = IntPtr.Zero;
            IntPtr ptrArguments = IntPtr.Zero;
            int retVal = FormatMessage(dwFlags, ref ptrlpSource, errorCode, 0, ref lpMsgBuf, messageSize, &ptrArguments);
            if (retVal == 0)
                throw new ApplicationException(string.Format("Failed to format message for error code '{0}'.", errorCode));
            return lpMsgBuf;
        }
        #endregion
    }
    }
