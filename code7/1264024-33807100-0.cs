    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    public class Impersonator : IDisposable
    {
    /// <summary>
    ///     The Impersonator class is used to access a network share with other credentials.
    /// </summary>
    private readonly WindowsImpersonationContext _impersonatedUser;
    private readonly IntPtr _userHandle;
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="username">The user of the network share</param>
    /// <param name="password">The password of the network share</param>
    public Impersonator(string username, string password, string userDomain =   "YOURDOMAIN")
    {
        _userHandle = new IntPtr(0);
        bool returnValue = LogonUser(username, userDomain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                                     ref _userHandle);
        if (!returnValue)
            throw new ApplicationException(
                "The applications wasn't able to impersonate the user with the specified credentials!");
        var newId = new WindowsIdentity(_userHandle);
        _impersonatedUser = newId.Impersonate();
    }
    #region IDisposable Members
    public void Dispose()
    {
        if (_impersonatedUser != null)
        {
            _impersonatedUser.Undo();
            CloseHandle(_userHandle);
        }
    }
    #endregion
    #region Interop imports/constants
    public const int LOGON32_LOGON_INTERACTIVE = 2;
    public const int LOGON32_LOGON_SERVICE = 3;
    public const int LOGON32_PROVIDER_DEFAULT = 0;
    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
    public static extern bool LogonUser(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType,
                                        int dwLogonProvider, ref IntPtr phToken);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool CloseHandle(IntPtr handle);
    #endregion
    }
