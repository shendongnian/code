    private Cursor OpenHand = CursorHelper.FromByteArray(Properties.Resources.CursorOpenHand);
    private Cursor GrabbingHand = CursorHelper.FromByteArray(Properties.Resources.CursorGrabbingHand);
    public MainWindow()
    {
        InitializeComponent();
        this.Cursor = OpenHand;
        this.MouseDown += this.MainWindow_MouseDown;
        this.MouseUp += this.MainWindow_MouseUp;
    }
    private void MainWindow_MouseDown(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = GrabbingHand;
    }
    private void MainWindow_MouseUp(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = OpenHand;
    }
