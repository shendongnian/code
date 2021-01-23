    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
        source.AddHook(WndProc);
    }
    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, 
    ref bool handled)
    {
        if(msg == (int)TaskbarNativeMethods.WM_DWMSENDICONICLIVEPREVIEWBITMAP)
        {
            // get your bitmap an SetIconicThumbnail...
        }
    }
