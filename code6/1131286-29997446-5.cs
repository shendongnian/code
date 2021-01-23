    public SetBrightness(Color c)
    {
        foreach (var monitor in ConnectedMonitors.Monitors)
            monitor.WithMonitorGraphics((m, g) => SetLCDbrightness(g, c));
    }
    private bool SetLCDbrightness(Graphics gg, Color c)
    {
        short red = c.R;
        short green = c.G;
        short blue = c.B;
        hdc = gg.GetHdc();
        unsafe
        {
            short* gArray = stackalloc short[3 * 256];
            short* idx = gArray;
            short brightness = 0;
            for (int j = 0; j < 3; j++)
            {
                if (j == 0) brightness = red;
                if (j == 1) brightness = green;
                if (j == 2) brightness = blue;
                for (int i = 0; i < 256; i++)
                {
                    int arrayVal = i * (brightness);
                    if (arrayVal > 65535) arrayVal = 65535;
                    *idx = (short)arrayVal;
                    idx++;
                }
            }
            // For some reason, this always returns false?
            bool retVal = SetDeviceGammaRamp(hdc, gArray);
        }
        return false;
    }
