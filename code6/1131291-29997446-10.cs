    /// <summary>
    /// This is an alternative that uses the Windows.Forms Screen class.
    /// </summary>
    public static class FormsScreens
    {
        public static void ForAllScreens(Action<Screen, IntPtr> actionWithHdc)
        {
            foreach (var screen in Screen.AllScreens)
                screen.WithHdc(actionWithHdc);
        }
        public static void WithHdc(this Screen screen, Action<Screen, IntPtr> action)
        {
            var hdc = IntPtr.Zero;
            try
            {
                hdc = CreateDC(null, screen.DeviceName, null, IntPtr.Zero);
                action(screen, hdc);
            }
            finally
            {
                if (!IntPtr.Zero.Equals(hdc))
                    DeleteDC(hdc);
            }
        }
        private const string GDI32 = @"gdi32.dll";
        [DllImport(GDI32, EntryPoint = "CreateDC", CharSet = CharSet.Auto)]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport(GDI32, CharSet = CharSet.Auto)]
        private static extern bool DeleteDC([In] IntPtr hdc);
    }
