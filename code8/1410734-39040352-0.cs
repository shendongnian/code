    private void Maximize()
	{
	    var hwnd = new System.Windows.Interop.WindowInteropHelper(this).EnsureHandle();
        var currentMonitor = NativeMethods.MonitorFromWindow(hwnd, NativeMethods.MONITOR_DEFAULTTONEAREST);
        var primaryMonitor = NativeMethods.MonitorFromWindow(IntPtr.Zero, NativeMethods.MONITOR_DEFAULTTOPRIMERTY);
        var isInPrimary = currentMonitor == primaryMonitor;
        // Don't want to hide the taskbar
        if (isInPrimary)
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        else
            this.MaxHeight = Double.PositiveInfinity;
	}
	
	protected override void OnStateChanged(EventArgs e)
	{
		if (WindowState == WindowState.Maximized && DoRefresh)
		{
			DoRefresh = false;
			WindowState = WindowState.Normal;
			Maximize();
			DoRefresh = true;
		}
	}
