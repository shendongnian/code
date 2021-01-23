    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Net.Sockets;
    using System.Globalization;
    using System.Reflection;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    namespace TestCulture
    {
    	class Program
    	{
    		static void SetEnglishCulture()
            {
    			CultureInfo ci = new CultureInfo("en-US");
    			Thread.CurrentThread.CurrentCulture = ci;
    			Thread.CurrentThread.CurrentUICulture = ci;
                Type type = typeof(CultureInfo);
                try
                {
                    type.InvokeMember("s_userDefaultCulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static, null, ci, new object[] { ci });
                    type.InvokeMember("s_userDefaultUICulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static, null, ci, new object[] { ci });
                } catch { }
                try
                {
                    type.InvokeMember("m_userDefaultCulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static, null, ci, new object[] { ci });
                    type.InvokeMember("m_userDefaultUICulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static, null, ci, new object[] { ci });
                } catch { }
            }
    		[DllImport("kernel32.dll")]
    		static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, uint nSize, IntPtr Arguments);
    		public static string Win32ExceptionInEnglish(Win32Exception ex)
    		{
    			const int nCapacity = 820; // max error length
    			const uint FORMAT_MSG_FROM_SYS = 0x01000;
    			const uint engLangID = (0x01<<10) | 0x09;
    			const uint defLangID = 0x0;
    			StringBuilder engSb = new StringBuilder(nCapacity);
    			StringBuilder defSb = new StringBuilder(nCapacity);
    			FormatMessage(FORMAT_MSG_FROM_SYS,IntPtr.Zero, (uint)ex.ErrorCode, defLangID, defSb, nCapacity, IntPtr.Zero);
    			FormatMessage(FORMAT_MSG_FROM_SYS,IntPtr.Zero, (uint)ex.ErrorCode, engLangID, engSb, nCapacity, IntPtr.Zero);
    			string sDefMsg = defSb.ToString().TrimEnd(' ','.','\r','\n');
    			string sEngMsg = engSb.ToString().TrimEnd(' ','.','\r','\n');
    			if(sDefMsg == sEngMsg) //message already in English (or no english on machine?)
    			{
    				//nothing left to do:
    				return ex.Message;
    			}
    			else
    			{
    				string msg = ex.Message.Replace(sDefMsg,sEngMsg);
    				if (msg == ex.Message)
    				{
    					//replace didn't worked, can be message with arguments in the middle.
    					//I such as case print both: original and translated. to not lose the arguments.
    					return ex.Message + " (In English: " + sEngMsg + ")";
    				}
    				else 
    				{
    					//successfuly replaced!
    					return msg;
    				}
    			}		
    		}
    		
    		public static void Main(string[] args)
    		{			
    			SetEnglishCulture();
    			try {
                    // generate any exception ...
    				const int notListenningPort = 2121;
    				new TcpClient("localhost", notListenningPort);
    			}
    			catch(Win32Exception ex)//first try to cach win32 Exceptions
    			{
    				Console.WriteLine("W32 Exception: " + Win32ExceptionInEnglish(ex));
    			}
    			catch(Exception ex)//this fit to the rest .NET exceptions which affected by CultureInfo
    			{
    				Console.WriteLine("Exception: " +ex.Message);
    			}	
    		}
    	}
    }
