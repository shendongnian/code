    // Reference to manually-loaded background image
    Image _bmp;
    // In your constructor, set these styles to ensure that the background
    // is not going to be automatically erased and filled with a color
    public Form1() {
        InitializeComponent();
        SetStyle(
            ControlStyles.Opaque |
            ControlStyles.OptimizedDoubleBuffer | 
            ControlStyles.AllPaintingInWmPaint, true);
        // Load background image
        _bmp = Image.FromFile("c:\\path\\to\\background.bmp");
    }
    // Override OnPaint to draw the background
    protected override void OnPaint(PaintEventArgs e) {
        var g = e.Graphics;
        var srcRect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
        int startY = Math.Max(0, (e.ClipRectangle.Top / _bmp.Height) * _bmp.Height);
        int startX = Math.Max(0, (e.ClipRectangle.Left / _bmp.Width) * _bmp.Width);
        for (int y = startY; y < e.ClipRectangle.Bottom; y+= _bmp.Height)
            for (int x = startX; x < e.ClipRectangle.Right; x += _bmp.Width)
            {
                var destRect = new Rectangle(x, y, _bmp.Width, _bmp.Height);
                g.DrawImage(_bmp, destRect, srcRect, GraphicsUnit.Pixel);
            }
        base.OnPaint(e);
    }
