    private Cursor OpenHand = CursorHelper.FromByteArray(Properties.Resources.CursorOpenHand);
    private Cursor GrabbingHand = CursorHelper.FromByteArray(Properties.Resources.CursorGrabbingHand);
    public Form1()
    {
        InitializeComponent();
        this.Cursor = OpenHand;
        this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
        this.MouseUp += new MouseEventHandler(this.Form1_MouseUp);
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = GrabbingHand;
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = OpenHand;
    }
