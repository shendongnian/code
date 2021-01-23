    // ConnectedMonitors variant
    public void SetBrightness(Color c)
    {
        foreach (var monitor in ConnectedMonitors.Monitors)
            monitor.WithMonitorHdc((m, hdc) => SetLCDbrightness(hdc, c));
    }
 
    // Variant using the Windows.Forms Screen class
    public void SetBrightness(Color c)
    {
        var setBrightness = new Action<Screen, IntPtr>((s, hdc) => SetLCDbrightness(hdc, c));
        FormsScreens.ForAllScreens(setBrightness);
    }
