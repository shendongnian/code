    AddHandler(Mouse.PreviewMouseDownOutsideCapturedElementEvent, 
                       new MouseButtonEventHandler((s, e) =>
                           {
                               Mouse.Capture(null);
                               if (e.LeftButton == MouseButtonState.Pressed)
                               {
                                   MouseInterop.LeftClick();
                               }
                            }));
    public static class MouseInterop
    {
        public static void LeftClick()
        {
            var x = (uint) Cursor.Position.X;
            var y = (uint) Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    }
