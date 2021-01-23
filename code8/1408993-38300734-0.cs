    var g = new Grid();
    var mv = new MyControl();
    g.Children.Add(mv);
    g.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    g.Arrange(new Rect(g.DesiredSize));
    g.UpdateLayout();
    var rtb = new RenderTargetBitmap((int)g.ActualWidth, (int)g.ActualHeight,
        96, 96, PixelFormats.Pbgra32);
    rtb.Render(g);
