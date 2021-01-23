    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    class Program
    {
        static void Main(string[] args)
        {
            var browserPath = @"chrome";
            RefreshBrowserTab(browserPath);
        }
    
        private static void RefreshBrowserTab(string browserPath)
        {
            var processName = Path.GetFileNameWithoutExtension(browserPath);
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                SetForegroundWindow(process.MainWindowHandle);
            }
            SendKeys.SendWait("^r");
        }
    
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
