    Timestamp: 2016-03-08 12:39:55.033
    Message: HandlingInstanceID: cd253adb-1e51-489a-8cf5-870568fb26ff
    An exception of type 'System.DirectoryServices.AccountManagement.PasswordException' occurred and was caught.
    ------------------------------------------------------------------------------------------------------------
    03/08/2016 12:39:54
    Type : System.DirectoryServices.AccountManagement.PasswordException, System.DirectoryServices.AccountManagement, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    Message : The specified network password is not correct. (Exception from HRESULT: 0x80070056)
    Source : System.DirectoryServices.AccountManagement
    Help link : 
    Data : System.Collections.ListDictionaryInternal
    TargetSite : Void ChangePassword(System.DirectoryServices.DirectoryEntry, System.String, System.String)
    HResult : -2146233087
    Stack Trace :    at System.DirectoryServices.AccountManagement.SDSUtils.ChangePassword(DirectoryEntry de, String oldPassword, String newPassword)
       at System.DirectoryServices.AccountManagement.ADStoreCtx.ChangePassword(AuthenticablePrincipal p, String oldPassword, String newPassword)
       at System.DirectoryServices.AccountManagement.PasswordInfo.ChangePassword(String oldPassword, String newPassword)
       at System.DirectoryServices.AccountManagement.AuthenticablePrincipal.ChangePassword(String oldPassword, String newPassword)
       at MyApplication.Web.UI.Infrastructure.ActiveDirectoryMembershipProvider.ChangePassword(String username, String oldPassword, String newPassword, LogonError& changePasswordLogonError)
    
    Additional Info:
    
    MachineName : SOME-SERVER
    TimeStamp : 3/8/2016 5:39:55 PM
    FullName : Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=3.1.0.0, Culture=neutral, PublicKeyToken=null
    AppDomainName : /LM/W3SVC/1/ROOT-3-131019323428219091
    ThreadIdentity : 
    WindowsIdentity : DOMAIN\App-Pool-Username
    	Inner Exception
    	---------------
    	Type : System.Runtime.InteropServices.COMException, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    	Message : The specified network password is not correct. (Exception from HRESULT: 0x80070056)
    	Source : 
    	Help link : 
    	ErrorCode : -2147024810
    	Data : System.Collections.ListDictionaryInternal
    	TargetSite : 
    	HResult : -2147024810
    	Stack Trace : The stack trace is unavailable.
