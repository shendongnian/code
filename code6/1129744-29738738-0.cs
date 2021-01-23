    static class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetSystemCursor(IntPtr hcur, uint id);
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        private static uint CROSS = 32515;
        private static uint NORMAL = 32512;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetSystemCursor(LoadCursor(IntPtr.Zero, (int)NORMAL), CROSS);
            Application.Run(new YOUR_SCREENSHOT_FORM());
            SetSystemCursor(LoadCursor(IntPtr.Zero, (int)CROSS), NORMAL);
        }
    }
