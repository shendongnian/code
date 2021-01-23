        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO Dummy);
        public static uint GetIdleTime()
        {
            var LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)Marshal.SizeOf(LastUserAction);
            GetLastInputInfo(ref LastUserAction);
            return ((uint)Environment.TickCount - LastUserAction.dwTime);
        }
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
       
        // Use System.Windows.Form.Timer Tick event for further calculations ...
