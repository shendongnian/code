    Point pnt;
    private POINT sourceLocation = new POINT (0, 0);
    private SIZE newSize = new SIZE(500, 500); //Form size
    private POINT newLocation;
    BLENDFUNCTION blend;
    public const int ULW_ALPHA = 2;
    public const byte AC_SRC_OVER = 0;
    public const byte AC_SRC_ALPHA = 1;
    public const int WS_EX_LAYERED = 524288;
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HTCAPTION = 0x2;
    public Form1()
    {
        InitializeComponent();
        this.Location = new Point(200, 200);
        bmp = new Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //the form region
        Region greenRegionOpacityX = new Region(new Rectangle (0, 0, 500, 500));
        Graphics g;
        g = Graphics.FromImage(bmp);
        g.Clear(Color.Transparent);
        g.FillRegion(new SolidBrush(Color.FromArgb(50, 0, 255, 0)), greenRegionOpacityX);
        g.Dispose();
        greenRegionOpacityX.Dispose();
        blend = new BLENDFUNCTION();
        // Only works with a 32bpp bitmap
        blend.BlendOp = AC_SRC_OVER;
        // Always 0
        blend.BlendFlags = 0;
        // Set to 255 for per-pixel alpha values
        blend.SourceConstantAlpha = 255;
        // Only works when the bitmap contains an alpha channel
        blend.AlphaFormat = AC_SRC_ALPHA;
        UpdateLayeredBitmap(bmp);
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            pnt = new Point(e.X, e.Y);
        }
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            //the form region
            Region greenRegionOpacityX = new Region(new Rectangle(0, 0, 500, 500));
            //we exclude the rectangle that we draw with the mouse
            greenRegionOpacityX.Exclude(new Rectangle(Math.Min(pnt.X, e.X), Math.Min(pnt.Y, e.Y),
                                                          Math.Abs(pnt.X - e.X), Math.Abs(pnt.Y - e.Y)));
            //the rectangle that we draw with the mouse
            Region greenRegionOpacityY = new Region(new Rectangle(Math.Min(pnt.X, e.X), Math.Min(pnt.Y, e.Y),
                                                                      Math.Abs(pnt.X - e.X), Math.Abs(pnt.Y - e.Y)));
                
            Graphics g;
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent); //we always clear the bitmap
            //draw the two regions
            g.FillRegion(new SolidBrush(Color.FromArgb(50, 0, 255, 0)), greenRegionOpacityX);
            g.FillRegion(new SolidBrush(Color.FromArgb(180, 0, 255, 0)), greenRegionOpacityY);
            g.Dispose();
            greenRegionOpacityX.Dispose();
            greenRegionOpacityY.Dispose();
            //upadate the layered window
            UpdateLayeredBitmap(bmp);
        }
    }
