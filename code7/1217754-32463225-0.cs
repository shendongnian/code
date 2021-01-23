        public static class dllRef
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetCursorPos(out Point lpPoint);
            [DllImport("user32.dll")]
            private static extern IntPtr WindowFromPoint(Point point);
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern int RegisterWindowMessage(string lpString);
            [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
            public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);
            public const int WM_USER = 0x400;
            public const int WM_COPYDATA = 0x4A;
            public const int WM_GETTEXT = 0x000D;
            public const int WM_GETTEXTLENGTH = 0x000E;
            public static void RegisterControlforMessages()
            {
                RegisterWindowMessage("WM_GETTEXT");
            }
            public static string GetText()
            {
                StringBuilder title = new StringBuilder();
                Point p = dllRef.getMousePosition();
                var lhwnd = dllRef.WindowFromPoint(p);
                var lTextlen = dllRef.SendMessage((int)lhwnd, dllRef.WM_GETTEXTLENGTH, 0, 0).ToInt32();
                if (lTextlen > 0)
                {
                    title = new StringBuilder(lTextlen + 1);
                    SendMessage(lhwnd, WM_GETTEXT, title.Capacity, title);
                }
                return title.ToString();
            }
            public static Point getMousePosition()
            {
                Point p = new Point();
                GetCursorPos(out p);
                return p;
            }
        }
