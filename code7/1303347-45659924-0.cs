    public MainWindow()
    {
        InitializeComponent();
        var graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero);
        var pixelWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width ;
        var pixelHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
        var pixelToDPI = 96.0 / graphics.DpiX ;
        this.Width = pixelWidth * pixelToDPI;
        this.Height = pixelHeight * pixelToDPI;
        this.Left = 0;
        this.Top = 0;
        this.WindowState = WindowState.Normal;
    }
