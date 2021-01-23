    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static async Task TestAsync()
    		{
    			ShowIdentity();
    
    			// substitute your actual test credentials
    			using (ImpersonateIdentity(
    				userName: "TestUser1", domain: "TestDomain", password: "TestPassword1"))
    			{
    				ShowIdentity();
    
    				await Task.Run(() =>
    				{
    					Thread.Sleep(100);
    
    					ShowIdentity();
    
    					ImpersonateIdentity(userName: "TestUser2", domain: "TestDomain", password: "TestPassword2");
    
    					ShowIdentity();
    				}).ConfigureAwait(false);
    
    				ShowIdentity();
    			}
    
    			ShowIdentity();
    		}
    
    		static WindowsImpersonationContext ImpersonateIdentity(string userName, string domain, string password)
    		{
    			var userToken = IntPtr.Zero;
    			
    			var success = NativeMethods.LogonUser(
    			  userName, 
    			  domain, 
    			  password,
    			  (int)NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE,
    			  (int)NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT,
    			  out userToken);
    
    			if (!success)
    			{
    				throw new SecurityException("Logon user failed");
    			}
    			try 
    			{	        
    				return WindowsIdentity.Impersonate(userToken);
    			}
    			finally
    			{
    				NativeMethods.CloseHandle(userToken);
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			TestAsync().Wait();
    			Console.ReadLine();
    		}
    
    		static void ShowIdentity(
    			[CallerMemberName] string callerName = "",
    			[CallerLineNumber] int lineNumber = -1,
    			[CallerFilePath] string filePath = "")
    		{
    			// format the output so I can double-click it in the Debuger output window
    			Debug.WriteLine("{0}({1}): {2}", filePath, lineNumber,
    				new { Environment.CurrentManagedThreadId, WindowsIdentity.GetCurrent().Name });
    		}
    
    		static class NativeMethods
    		{
    			public enum LogonType
    			{
    				LOGON32_LOGON_INTERACTIVE = 2,
    				LOGON32_LOGON_NETWORK = 3,
    				LOGON32_LOGON_BATCH = 4,
    				LOGON32_LOGON_SERVICE = 5,
    				LOGON32_LOGON_UNLOCK = 7,
    				LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
    				LOGON32_LOGON_NEW_CREDENTIALS = 9
    			};
    
    			public enum LogonProvider
    			{
    				LOGON32_PROVIDER_DEFAULT = 0,
    				LOGON32_PROVIDER_WINNT35 = 1,
    				LOGON32_PROVIDER_WINNT40 = 2,
    				LOGON32_PROVIDER_WINNT50 = 3
    			};
    
    			public enum ImpersonationLevel
    			{
    				SecurityAnonymous = 0,
    				SecurityIdentification = 1,
    				SecurityImpersonation = 2,
    				SecurityDelegation = 3
    			}
    
    			[DllImport("advapi32.dll", SetLastError = true)]
    			public static extern bool LogonUser(
    					string lpszUsername,
    					string lpszDomain,
    					string lpszPassword,
    					int dwLogonType,
    					int dwLogonProvider,
    					out IntPtr phToken);
    
    			[DllImport("kernel32.dll", SetLastError=true)]
    			public static extern bool CloseHandle(IntPtr hObject);
    		}
    	}
    }
