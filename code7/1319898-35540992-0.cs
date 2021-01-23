        private void button1_Click(object sender, EventArgs e)
        {
            KeyDown(ConsoleKey.LeftWindows);
            KeyDown(ConsoleKey.P);
            KeyUp(ConsoleKey.LeftWindows);
            KeyUp(ConsoleKey.P);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;
        public static void KeyDown(ConsoleKey vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }
        public static void KeyUp(ConsoleKey vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
