    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
        
        static void Main(string[] args)
        {
            /// Give this your app's process name.
            Process[] processes = Process.GetProcessesByName("yourapp");
            Process lol = processes[0];
            IntPtr ptr = lol.MainWindowHandle;
            Rect AppRect = new Rect();
            GetWindowRect(ptr, ref AppRect);
            Rectangle rect = new Rectangle(AppRect.Left, AppRect.Top, (AppRect.Right - AppRect.Left), (AppRect.Bottom - AppRect.Top));
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            // make sure temp directory is there or it will throw.
            bmp.Save(@"c:\temp\test.jpg", ImageFormat.Jpeg);
        }
    }
