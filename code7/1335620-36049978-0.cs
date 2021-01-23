    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    public partial class MainWindow : Window
    {
        private const int WM_MOVING = 0x0216;
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        private int _left;
        private int _width;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _left = (int)this.Left;
            _width = (int)this.Width;
            var handle = new WindowInteropHelper(this).Handle;
            var source = HwndSource.FromHwnd(handle);
            source.AddHook(new HwndSourceHook(WndProc));
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_MOVING)
            {
                var position = Marshal.PtrToStructure<RECT>(lParam);
                position.left = _left;
                position.right = position.left + _width;
                Marshal.StructureToPtr(position, lParam, true);
            }
            return IntPtr.Zero;
        }
    }
