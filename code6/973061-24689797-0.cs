    static class Program
    {
        private const int WmSyscommand = 0x0112;
        private const int ScMonitorpower = 0xF170;
        private const int HwndBroadcast = 0xFFFF;
        private const int ShutOffDisplay = 2;
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg,
                      IntPtr wParam, IntPtr lParam);
        private static void TurnOffDisplay()
        {
            PostMessage((IntPtr)HwndBroadcast, (uint)WmSyscommand,
                    (IntPtr)ScMonitorpower, (IntPtr)ShutOffDisplay);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LockWorkStation();
            TurnOffDisplay();
        }
    }
