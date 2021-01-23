        using System.Windows.Interop;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
        
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 8: //WM_KILLFOCUS
                    MainGridBlur.Radius = 10;
                    break;
                case 7: //WM_SETFOCUS
                    MainGridBlur.Radius = 0;
                    break;
            }
            return IntPtr.Zero;
        }
