    private Cursor OpenHand = CursorHelper.FromByteArray(Properties.Resources.CursorOpenHand);
    private Cursor GrabbingHand = CursorHelper.FromByteArray(Properties.Resources.CursorGrabbingHand);
    private void Form1_Load(object sender, EventArgs e)
    {
        this.Cursor = OpenHand;
        this.MouseDown += new MouseEventHandler(this.Control_MouseDown);
        this.MouseUp += new MouseEventHandler(this.Control_MouseUp);
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = GrabbingHand;
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = OpenHand;
    }
