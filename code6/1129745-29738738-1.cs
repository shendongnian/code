    static class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetSystemCursor(IntPtr hcur, uint id);
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        [DllImport("user32.dll")]
        static extern IntPtr SystemParametersInfo(uint uiAction, uint uiParam, object pvParam, uint fWinIni);
        private static uint CROSS = 32515;
        private static uint NORMAL = 32512;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetSystemCursor(LoadCursor(IntPtr.Zero, 32512), 32515);
            Application.Run(new ZeroOpacity());
            SystemParametersInfo(0x0057, 0, null, 0);
        }
    }
