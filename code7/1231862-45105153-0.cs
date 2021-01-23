    public class WindowSnapper
    {
        private struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
            public int Height
            {
                get { return Bottom - Top; }
            }
            public static bool operator !=(Rect r1, Rect r2)
            {
                return !(r1 == r2);
            }
            public static bool operator ==(Rect r1, Rect r2)
            {
                return r1.Left == r2.Left && r1.Right == r2.Right && r1.Top == r2.Top && r1.Bottom == r2.Bottom;
            }
        }
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        private DispatcherTimer _timer;
        private IntPtr _windowHandle;
        private Rect _lastBounds;
        private Window _window;
        private string _windowTitle;
        public WindowSnapper(Window window, String windowTitle)
        {
            _window = window;
            _window.Topmost = true;
            _windowTitle = windowTitle;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += (x, y) => SnapToWindow();
            _timer.IsEnabled = false;
        }
        public void Attach()
        {
            _windowHandle = GetWindowHandle(_windowTitle);
            _timer.Start();
        }
        public void Detach()
        {
            _timer.Stop();
        }
        private void SnapToWindow()
        {
            var bounds = GetWindowBounds(_windowHandle);
            if (bounds != _lastBounds)
            {
                _window.Top = bounds.Top;
                _window.Left = bounds.Left - _window.Width;
                _window.Height = bounds.Height;
                _lastBounds = bounds;
            }
        }
        private Rect GetWindowBounds(IntPtr handle)
        {
            Rect bounds = new Rect();
            GetWindowRect(handle, ref bounds);
            return bounds;
        }
        private IntPtr GetWindowHandle(string windowTitle)
        {
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(windowTitle))
                {
                    return pList.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }
    }
