    private Timer _Ticker = new Timer();
    private PowerPoint.SlideShowWindow _SlideshowWindow = null;
    private void Application_SlideShowBegin(PowerPoint.SlideShowWindow Wn)
    {
        _SlideshowWindow = Wn;
        _Ticker.Interval = 30;
        _Ticker.AutoReset = true;
        _Ticker.Elapsed += Ticker_Elapsed;
        _Ticker.Enabled = true;
    }
    private void Ticker_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_Ticker.Enabled)
        {
            using (var g = Graphics.FromHwnd((IntPtr)_SlideshowWindow.HWND))
            {
                g.DrawLine(new Pen(Color.Red, 10), new System.Drawing.Point(100, 100), new System.Drawing.Point(200, 300));
                Image img = Properties.Resources.img;
                g.DrawImageUnscaled(img, new Rectangle(250, 250, img.Width, img.Height));
            }
        }
    }
