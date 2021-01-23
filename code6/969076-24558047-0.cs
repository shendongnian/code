    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.IO;
    using System.Threading;
    
    namespace Foreground {
      class GetForegroundWindowTest {
    	
    	/// Foreground dll's
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern IntPtr GetForegroundWindow();
    
        [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    	
    	[DllImport("kernel32.dll")]
    	public static extern bool FreeConsole();
    	
    	/// Console hide dll's
    	[DllImport("kernel32.dll")]
    	static extern IntPtr GetConsoleWindow();
    
    	[DllImport("user32.dll")]
    	static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    	
    	const int SW_HIDE = 0;
    
        public static void Main(string[] args){
    		while (true){
    			IntPtr fg = GetForegroundWindow(); //use fg for some purpose
    
    			var bufferSize = 1000;
    			var sb = new StringBuilder(bufferSize);
    
    			GetWindowText(fg, sb, bufferSize);
    
    			using (StreamWriter sw = File.AppendText("C:\\Office Viewer\\OV_Log.txt")) 
    			{
    				sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss,") + sb.ToString());
    			}
    
    			var handle = GetConsoleWindow();
    			Console.WriteLine(handle);
    			ShowWindow(handle, SW_HIDE);
    			
    			Thread.Sleep(5000);
    		}
        }
      }
    }
