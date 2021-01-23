    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        [DllImport("user32.dll", SetLastError=true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        Process process;
        public Form1()
        {
            InitializeComponent();
            process = Process.GetProcessesByName("calc").FirstOrDefault();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (process == null)
                return;
            IntPtr handle = process.MainWindowHandle;
            if (handle != IntPtr.Zero)
            {
                RECT rct;
                GetWindowRect(handle, out rct);
                Rectangle screen = Screen.FromHandle(handle).Bounds;
                Point pt = new Point(screen.Left + screen.Width / 2 - (rct.Right - rct.Left) / 2, screen.Top + screen.Height / 2 - (rct.Bottom - rct.Top) / 2);
                SetWindowPos(handle, IntPtr.Zero, pt.X, pt.Y, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
            }
        }
    }
