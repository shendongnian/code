    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Linq;
    using System.Text;
    
    namespace TopSekrit.Credentials
    {
        public class UserImpersonator : IDisposable
        {
            #region Delegates
            // Port from generic event handler
            public delegate void SimpleEventDelegate(SimpleEventArgument Argument);
            #endregion
            #region Supporting Classes
            // Port from generic event handler
            public class SimpleEventArgument
            {
                public Object Source = null;
                public Object Message = null;
                public SimpleEventArgument(Object Source, String Message)
                {
                    this.Source = Source;
                    this.Message = Message;
                }
            }
            #endregion
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
    
            #region Events
            public event SimpleEventDelegate OnImpersonationReset = null;
    
            public event SimpleEventDelegate OnImpersonationOpened = null;
            public event SimpleEventDelegate OnImpersonationClosed = null;
    
            public event SimpleEventDelegate OnImpersonatedExecutionStarted = null;
            public event SimpleEventDelegate OnImpersonatedExecutionFinished = null;
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
                    if (this.IsExecuting)
                        throw new InvalidOperationException("Cannot set Username on UserImpersonator while impersonation is executing.");
                    else if (this.IsOpen)
                        throw new InvalidOperationException("Cannot set Username on UserImpersonator while impersonation context is open.");
                    else
                    {
                        this._Username = value;
    
                        this.ResetImpersonation();
                    }
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
                    if (this.IsExecuting)
                        throw new InvalidOperationException("Cannot set Password on UserImpersonator while impersonation is executing.");
                    else if (this.IsOpen)
                        throw new InvalidOperationException("Cannot set Password on UserImpersonator while impersonation context is open.");
                    else
                    {
                        this._Password = value;
    
                        this.ResetImpersonation();
                    }
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
                    if (this.IsExecuting)
                        throw new InvalidOperationException("Cannot set Domain on UserImpersonator while impersonation is executing.");
                    else if (this.IsOpen)
                        throw new InvalidOperationException("Cannot set Domain on UserImpersonator while impersonation context is open.");
                    else
                    {
                        this._Domain = value;
    
                        this.ResetImpersonation();
                    }
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
    
            protected Boolean _IsExecuting = false;
    
            public Boolean IsExecuting
            {
                get
                {
                    return this._IsExecuting;
                }
            }
    
            public Boolean IsOpen
            {
                get
                {
                    if (this.PrimaryToken != null)
                        return true;
                    else if (this.MutatedToken != null)
                        return true;
                    else if (this.TargetIdentity != null)
                        return true;
                    else if (this.ImpersonationContext != null)
                        return true;
                    else
                        return false;
                }
            }
    
            protected int _LogonType = LOGON32_LOGON_INTERACTIVE;
    
            public int LogonType
            {
                get
                {
                    return this._LogonType;
                }
    
                set
                {
                    if (this.IsExecuting)
                        throw new InvalidOperationException("Cannot set LogonType on UserImpersonator while impersonation is executing.");
                    else if (this.IsOpen)
                        throw new InvalidOperationException("Cannot set LogonType on UserImpersonator while impersonation context is open.");
                    else
                    {
                        this._LogonType = value;
    
                        this.ResetImpersonation();
                    }
                }
            }
    
            protected int _LogonProvider = LOGON32_PROVIDER_DEFAULT;
    
            public int LogonProvider
            {
                get
                {
                    return this._LogonProvider;
                }
    
                set
                {
                    if (this.IsExecuting)
                        throw new InvalidOperationException("Cannot set LogonProvider on UserImpersonator while impersonation is executing.");
                    else if (this.IsOpen)
                        throw new InvalidOperationException("Cannot set LogonProvider on UserImpersonator while impersonation context is open.");
                    else
                    {
                        this._LogonProvider = value;
    
                        this.ResetImpersonation();
                    }
                }
            }
            #endregion
    
            #region Constructors
            public UserImpersonator(String Username,String Password,String Domain,System.Delegate Method,int LogonType,int LogonProvider)
            {
                if (String.IsNullOrEmpty(Username))
                    throw new ArgumentNullException();
                else
                {
                    this._Username = Username;
                    this._Password = Password;
                    this._Domain = Domain;
    
                    this._Method = Method;
    
                    this._LogonType = LogonType;
                    this._LogonProvider = LogonProvider;
    
                    return;
                }
            }
    
            public UserImpersonator(String Username, String Password, String Domain, System.Delegate Method, int LogonType)
                : this(Username, Password, Domain, Method, LogonType, LOGON32_PROVIDER_DEFAULT)
            {
    
            }
            
            public UserImpersonator(String Username, String Password, String Domain, System.Delegate Method)
                : this(Username,Password,Domain,Method,LOGON32_LOGON_INTERACTIVE)
            {
    
            }
    
            public UserImpersonator(String Username, String Password, String Domain)
                :this( Username, Password, Domain, null)
            {
            }
    
            public UserImpersonator(String Username, String Password)
                : this(Username, Password,String.Empty)
            {
    
            }
    
            public UserImpersonator(String Username)
                : this(Username, String.Empty)
            {
    
            }
            #endregion
    
            #region Impersonated Execution
            public virtual Object Execute()
            {
                if (this.IsExecuting)
                    throw new InvalidOperationException("UserImpersonator cannot Execute while another execution is already in progress.");
                else if (this.Method == null)
                    throw new InvalidOperationException("UserImpersonator cannot Execute without a supplied, or stored Method to invoke.");
                else if (!this.Open())
                    throw new InvalidOperationException("Could not open security context.");
                else
                {
                    try
                    {
                        this._IsExecuting = true;
    
                        Object ReturnValue = this.Method.DynamicInvoke();
    
                        this.Close();
    
                        this._IsExecuting = false;
    
                        return ReturnValue;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
    
            public virtual Object Execute(params object[] Arguments)
            {
                if (this.IsExecuting)
                    throw new InvalidOperationException("UserImpersonator cannot Execute while another execution is already in progress.");
                else if (this.Method == null)
                    throw new InvalidOperationException("UserImpersonator cannot Execute without a supplied, or stored Method to invoke.");
                else if (!this.Open())
                    throw new InvalidOperationException("Could not open security context.");
                else
                {
                    try
                    {
                        this._IsExecuting = true;
    
                        Object ReturnValue = this.Method.DynamicInvoke(Arguments);
    
                        this.Close();
    
                        this._IsExecuting = false;
    
                        return ReturnValue;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
    
            public virtual Object Execute(System.Delegate Method)
            {
                if (this.IsExecuting)
                    throw new InvalidOperationException("UserImpersonator cannot Execute while another execution is already in progress.");
                else if (Method == null)
                    throw new InvalidOperationException("UserImpersonator cannot Execute without a supplied, or stored Method to invoke.");
                else if (!this.Open())
                    throw new InvalidOperationException("Could not open security context.");
                else
                {
                    try
                    {
                        this._IsExecuting = true;
    
                        Object ReturnValue = Method.DynamicInvoke();
    
                        this.Close();
    
                        this._IsExecuting = false;
    
                        return ReturnValue;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
    
            public virtual Object Execute(System.Delegate Method, params object[] Arguments)
            {
                if (this.IsExecuting)
                    throw new InvalidOperationException("UserImpersonator cannot Execute while another execution is already in progress.");
                else if (Method == null)
                    throw new InvalidOperationException("UserImpersonator cannot Execute without a supplied, or stored Method to invoke.");
                else if (!this.Open())
                    throw new InvalidOperationException("Could not open security context.");
                else
                {
                    try
                    {
                        this._IsExecuting = true;
    
                        Object ReturnValue = Method.DynamicInvoke(Arguments);
    
                        this.Close();
    
                        this._IsExecuting = false;
    
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
            public virtual Boolean Open()
            {
                if (this.IsOpen)
                {
                    if( this.IsExecuting )
                        throw new InvalidOperationException("UserImpersonator cannot Open user context while a user context is already open and executing.");
                    else
                    {
                        this.Close();
    
                        return this.Open();
                    }
                }
                else if (!LogonUser(this.Username, this.Domain, this.Password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref this.PrimaryToken))
                    throw this.GetLastException();
                else if (!DuplicateToken(this.PrimaryToken, 2, ref this.MutatedToken))
                    throw this.GetLastException();
                else
                {
                    try
                    {
                        this._TargetIdentity = new WindowsIdentity(this.MutatedToken);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("UserImpersonator could not Open user context. An exception was encountered while creating the WindowsIdentity.\r\n" + e.Message + "\r\n" + e.StackTrace);
                    }
                    finally
                    {
                        try
                        {
                            this._ImpersonationContext = this._TargetIdentity.Impersonate();
                        }
                        catch (Exception e)
                        {
                            throw new Exception("UserImpersonator could not Open user context. An exception was encountered while creating the WindowsImpersonationContext.\r\n" + e.Message + "\r\n" + e.StackTrace);
                        }
                        finally
                        {
                            this.FireImpersonationOpened();
                        }
                    }
                    return true;
                }
            }
    
            public virtual void Close()
            {
                if (this.IsExecuting)
                    throw new InvalidOperationException("UserImpersonator cannot Close impersonation context while in execution.");
                else
                {
                    try
                    {
                        if (this._TargetIdentity != null)
                        {
                            this._TargetIdentity.Dispose();
                            this._TargetIdentity = null;
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Exception encountered while disposing TargetIdentity on UserImpersonator.\r\n" + e.Message + "\r\n" + e.StackTrace);
                    }
                    finally
                    {
                        try
                        {
                            if (this._ImpersonationContext != null)
                            {
                                this._ImpersonationContext.Undo();
                                this._ImpersonationContext.Dispose();
                                this._ImpersonationContext = null;
                            }
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Exception encountered while undoing or disposing ImpersonationContext on UserImpersonator.\r\n" + e.Message + "\r\n" + e.StackTrace);
                        }
                        finally
                        {
                            try
                            {
                                if (this.MutatedToken != null)
                                    if (!CloseHandle(MutatedToken))
                                        this.GetLastException();
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Exception encountered while closing MutatedToken on UserImpersonator.\r\n" + e.Message + "\r\n" + e.StackTrace);
                            }
                            finally
                            {
                                try
                                {
                                    if (this.PrimaryToken != null)
                                        if (!CloseHandle(this.PrimaryToken))
                                            this.GetLastException();
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("Exception encountered while closing PrimaryToken on UserImpersonator.\r\n" + e.Message + "\r\n" + e.StackTrace);
                                }
                                finally
                                {
                                    this.FireImpersonationClosed();
                                }
                            }
                        }
                    }
                    return;
                }
            }
    
            protected virtual void ResetImpersonation()
            {
                if (this.IsExecuting)
                    throw new InvalidOperationException("UserImpersonator cannot ResetImpersonation while impersonation is already executing.");
                else if (this.IsOpen)
                {
                    this.Close();
    
                    this.ResetImpersonation();
    
                    return;
                }
                else
                {
                    this.Open();
    
                    this.FireImpersonationReset();
    
                    return;
                }
            }
            #endregion
    
            #region Error Handling
            private Exception GetLastException()
            {
                return new ApplicationException(this.GetErrorMessage(Marshal.GetLastWin32Error()));
            }
    
            public unsafe string GetErrorMessage(int ErrorCode)
            {
                int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
                int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
                int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
    
                int messageSize = 255;
                string lpMsgBuf = "";
                int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;
    
                IntPtr ptrlpSource = IntPtr.Zero;
                IntPtr ptrArguments = IntPtr.Zero;
    
                int retVal = FormatMessage(dwFlags, ref ptrlpSource, ErrorCode, 0, ref lpMsgBuf, messageSize, &ptrArguments);
    
                if (retVal == 0)
                    return string.Format("Failed to format message for error code '{0}'.", ErrorCode);
    
                return lpMsgBuf;
            }
            #endregion
    
            #region Disposability
            public virtual void Dispose()
            {
                this.Close();
    
                this.Username = null;
                this.Password = null;
                this.Domain = null;
                this.Method = null;
    
                return;
            }
            #endregion
    
            #region Event Firing
            protected virtual void FireImpersonationReset()
            {
                if (this.OnImpersonationReset != null)
                    this.OnImpersonationReset(new Events.SimpleArgument(this, "Impersonation context has been reset."));
                return;
            }
    
            protected virtual void FireImpersonationOpened()
            {
                if (this.OnImpersonationOpened != null)
                    this.OnImpersonationOpened(new Events.SimpleArgument(this, "Impersonation context has been opened."));
                return;
            }
    
            protected virtual void FireImpersonationClosed()
            {
                if (this.OnImpersonationClosed != null)
                    this.OnImpersonationClosed(new Events.SimpleArgument(this, "Impersonation context has been closed."));
                return;
    
            }
    
            protected virtual void FireImpersonationExecutionStarted()
            {
                if (this.OnImpersonatedExecutionStarted != null )
                    this.OnImpersonatedExecutionStarted(new Events.SimpleArgument(this, "Impersonated execution has started."));
                return;
            }
    
            protected virtual void FireImpersonationExecutionFinished()
            {
                if (this.OnImpersonatedExecutionFinished != null)
                    this.OnImpersonatedExecutionFinished(new Events.SimpleArgument(this, "Impersonated execution has finished."));
                return;
            }
            #endregion
        }
    }
