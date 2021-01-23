    public class ChromeWrapper
    {
        // you might as well use those methods from your helper class
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // the keystroke signals. you can look them up at the msdn pages
        private static uint WM_KEYDOWN = 0x100, WM_KEYUP = 0x101;
        // the reference to the chrome process
        private Process chromeProcess;
        
        public ChromeWrapper(string url)
        {
            // i'm using the process class as it gives you the MainWindowHandle by default
            chromeProcess = new Process();
            chromeProcess.StartInfo = new ProcessStartInfo("chrome.exe", url);
            chromeProcess.Start();
        }
        public void SendKey(char key)
        {
            if (chromeProcess.MainWindowHandle != IntPtr.Zero)
            {
                // send the keydown signal
                SendMessage(chromeProcess.MainWindowHandle, ChromeWrapper.WM_KEYDOWN, (IntPtr)key, IntPtr.Zero);
                
                // give the process some time to "realize" the keystroke
                System.Threading.Thread.Sleep(100); 
                // send the keyup signal
                SendMessage(chromeProcess.MainWindowHandle, ChromeWrapper.WM_KEYUP, (IntPtr)key, IntPtr.Zero);
            }
        }
    }
