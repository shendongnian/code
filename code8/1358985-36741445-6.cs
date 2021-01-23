        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        public static Bitmap CaptureWindow(IntPtr handle)
        {
            
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            if (bounds.Width == 0 && bounds.Height == 0)
            {
                bounds.Width = 1;
                bounds.Height = 1;
            }
            var result = new Bitmap(bounds.Width, bounds.Height);
            if(bounds.Width != 1 )
                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
            return result;
        }
