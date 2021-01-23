    namespace NativeMethods
    {
        public static class User32
        {
            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref RECT lParam);
        }
    }
