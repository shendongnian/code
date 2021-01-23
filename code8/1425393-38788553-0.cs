        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;//0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;//0x04;
        public void Click(int x, int y)
        {
            Thread.Sleep(2000);
            SetCursorPos(x, y);
            Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
