    static class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetSystemCursor(IntPtr hcur, uint id);
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32
        uiParam, String pvParam, UInt32 fWinIni);
        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr pcur);
        private static uint CROSS = 32515;
        private static uint NORMAL = 32512;
        private static uint IBEAM = 32513;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            uint[] Cursors = {NORMAL, IBEAM};
            for (int i = 0; i < Cursors.Length; i++)
                SetSystemCursor(CopyIcon(LoadCursor(IntPtr.Zero, (int)CROSS)), Cursors[i]);
            Application.Run(new Form1());
            SystemParametersInfo(0x0057, 0, null, 0);
        }
    }
