    var device = Resolver.Resolve<IDevice>();
    var display = device.Display;
    if (display != null)
    {  	
        System.Diagnostics.Debug.WriteLine(display.ScreenHeightInches());
        System.Diagnostics.Debug.WriteLine(display.ScreenWidthInches());
    }
