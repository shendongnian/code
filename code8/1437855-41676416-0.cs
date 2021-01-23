    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    public class ClipboardMonitorWindow : Window
    {
        private const int WM_CLIPBOARDUPDATE = 0x031D;
        private IntPtr windowHandle;
        public event EventHandler ClipboardUpdate;
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            windowHandle = new WindowInteropHelper(this).EnsureHandle();
            HwndSource.FromHwnd(windowHandle)?.AddHook(HwndHandler);
            Start();
        }
        public static readonly DependencyProperty ClipboardUpdateCommandProperty =
            DependencyProperty.Register("ClipboardUpdateCommand", typeof(ICommand), typeof(ClipboardMonitorWindow), new FrameworkPropertyMetadata(null));
        public ICommand ClipboardUpdateCommand
        {
            get { return (ICommand)GetValue(ClipboardUpdateCommandProperty); }
            set { SetValue(ClipboardUpdateCommandProperty, value); }
        }
        protected virtual void OnClipboardUpdate()
        { }
        public void Start()
        {
            NativeMethods.AddClipboardFormatListener(windowHandle);
        }
        public void Stop()
        {
            NativeMethods.RemoveClipboardFormatListener(windowHandle);
        }
        private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg == WM_CLIPBOARDUPDATE)
            {
                // fire event
                this.ClipboardUpdate?.Invoke(this, new EventArgs());
                // execute command
                if (this.ClipboardUpdateCommand?.CanExecute(null) ?? false)
                {
                    this.ClipboardUpdateCommand?.Execute(null);
                }
                // call virtual method
                OnClipboardUpdate();
            }
            handled = false;
            return IntPtr.Zero;
        }
        private static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AddClipboardFormatListener(IntPtr hwnd);
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        }
    }
    
