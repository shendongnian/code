    public static class WindowHelper
    {
        private static Dictionary<IntPtr, int> _extendedStyleHwndDictionary = new Dictionary<IntPtr, int>();
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
        
        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            if (_extendedStyleHwndDictionary.Keys.Contains(hwnd) == false)
            {
                _extendedStyleHwndDictionary.Add(hwnd, extendedStyle);
            }
        }
        public static void UndoWindowExTransparent(IntPtr hwnd, FrameworkElement elementInPopup)
        {
            if (_extendedStyleHwndDictionary.Keys.Contains(hwnd) == true)
            {
                int extendedStyle = _extendedStyleHwndDictionary[hwnd];
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle);
                // Fix Focus problems that forces the users to click twice to
                // re-activate the window after the Popup loses event transparency
                elementInPopup.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Keyboard.Focus(elementInPopup);
                    Mouse.Capture(elementInPopup);
                    elementInPopup.ReleaseMouseCapture();
                }));
            }
        }
    }
