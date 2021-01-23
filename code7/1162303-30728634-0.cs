    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace Temp
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool IsDone = false;
    
                while (IsDone == false)
                {
                    // Get a handle to the Firefox application. The window class 
                    // and window name were obtained using the Spy++ tool.
                    IntPtr firefoxHandle = FindWindow("MozillaWindowClass", null);
    
                    // Verify that Firefox is a running process. 
                    if (firefoxHandle == IntPtr.Zero)
                    {
                        // log of errors
                        Console.WriteLine("Firefox is not running.");
    
                        // wait 1 sec and retry
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }
    
                    // Make Firefox the foreground application and send it commands 
                    SetForegroundWindow(firefoxHandle);
    
                    // send keys to window
                    System.Windows.Forms.SendKeys.SendWait("google.com");
                    System.Windows.Forms.SendKeys.SendWait("{tab}");
                    System.Windows.Forms.SendKeys.SendWait("{enter}");
    
                    // yeah ! job's done
                    IsDone = true;
                }
            }
            
            // Get a handle to an application window.
            [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string lpClassName,
                string lpWindowName);
    
            // Activate an application window.
            [DllImport("USER32.DLL")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
        }
    }
 
