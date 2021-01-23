    public partial class MainWindow : IDisposable
    {
    ...
            protected override void OnSourceInitialized(EventArgs e)
            {
                base.OnSourceInitialized(e);
                HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
                source.AddHook(WndProc);
            }
    
            private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
                if (msg == WM_DISPLAYCHANGE)
                {
                    int lparamInt = lParam.ToInt32();
    
                    uint width = (uint)(lparamInt & 0xffff);
                    uint height = (uint)(lparamInt >> 16);
                    
                    int monCount = ScreenInformation.GetMonitorCount();
                    int winFormsMonCount = System.Windows.Forms.Screen.AllScreens.Length;
    
                    _viewModel.MonitorCountChanged(monCount);
                }
    
                return IntPtr.Zero;
            }
