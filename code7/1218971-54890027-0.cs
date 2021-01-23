        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
        private static Bitmap Screenshot()
        {
            SetProcessDPIAware();
            var screen = System.Windows.Forms.Screen.PrimaryScreen;
            var rect = screen.Bounds;
            var size = rect.Size;
            Bitmap bmpScreenshot = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bmpScreenshot);
            g.CopyFromScreen(0, 0, 0, 0, size);
            return bmpScreenshot;
        }
