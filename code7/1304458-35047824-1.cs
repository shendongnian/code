    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace MessageLoop
    {
    	public enum WtsSessionChange
    	{
    		WTS_CONSOLE_CONNECT = 1,
    		WTS_CONSOLE_DISCONNECT = 2,
    		WTS_REMOTE_CONNECT = 3,
    		WTS_REMOTE_DISCONNECT = 4,
    		WTS_SESSION_LOGON = 5,
    		WTS_SESSION_LOGOFF = 6,
    		WTS_SESSION_LOCK = 7,
    		WTS_SESSION_UNLOCK = 8,
    		WTS_SESSION_REMOTE_CONTROL = 9,
    		WTS_SESSION_CREATE = 0xA,
    		WTS_SESSION_TERMINATE = 0xB
    	}
    	public enum SessionNotificationType
    	{
    		NOTIFY_FOR_THIS_SESSION = 0,
    		NOTIFY_FOR_ALL_SESSIONS = 1
    	}
    	public static class NativeWrapper
    	{
    		public static void WTSRegisterSessionNotification(Control control, SessionNotificationType sessionNotificationType)
    		{
    			if (!Native.WTSRegisterSessionNotification(control.Handle, (int)sessionNotificationType))
    				throw new Win32Exception(Marshal.GetLastWin32Error()); 
    		}
    		public static void WTSUnRegisterSessionNotification(Control control)
    		{
    			if (!Native.WTSUnRegisterSessionNotification(control.Handle))
    				throw new Win32Exception(Marshal.GetLastWin32Error());
    		}
    		public static string GetUsernameBySessionId(int sessionId)
    		{			
    			IntPtr buffer;
    			int strLen;
    			var username = "SYSTEM"; // assume SYSTEM as this will return "\0" below
    			if (Native.WTSQuerySessionInformation(IntPtr.Zero, sessionId, Native.WTS_INFO_CLASS.WTSUserName, out buffer, out strLen) && strLen > 1)
    			{
    				username = Marshal.PtrToStringAnsi(buffer); // don't need length as these are null terminated strings
    				Native.WTSFreeMemory(buffer);
    				if (Native.WTSQuerySessionInformation(IntPtr.Zero, sessionId, Native.WTS_INFO_CLASS.WTSDomainName, out buffer, out strLen) && strLen > 1)
    				{
    					username = Marshal.PtrToStringAnsi(buffer) + "\\" + username; // prepend domain name
    					Native.WTSFreeMemory(buffer);
    				}
    			}
    			return username;
    		}
    	}
    }
