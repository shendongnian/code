    System.Windows.Media.Matrix toDevice;
    using (var source = new HwndSource(new HwndSourceParameters()))
    {
        toDevice = source.CompositionTarget.TransformToDevice;
    }
    screenWidth = (int)Math.Round(SystemParameters.PrimaryScreenWidth * toDevice.M11);
    screenHeight = (int)Math.Round(SystemParameters.PrimaryScreenHeight * toDevice.M22);
