    // Reference to manually-loaded background image
    Image _background;
    // In your constructor, set these styles to ensure that the background
    // is not going to be automatically erased and filled with a color
    public Form1() {
        InitializeComponent();
        SetStyle(
            ControlStyles.Opaque |
            ControlStyles.OptimizedDoubleBuffer | 
            ControlStyles.AllPaintingInWmPaint, true);
        // Load background image
        _background = Image.FromFile("c:\\path\\to\\background.bmp");
    }
    // Override OnPaint to draw the background
    protected override void OnPaint(PaintEventArgs e) {
        e.Graphics.DrawImage(_background, 0, 0);
        base.OnPaint(e);
    }
