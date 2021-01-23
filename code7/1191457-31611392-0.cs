    public Form1()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        var p = PointToClient(Cursor.Position);
        e.Graphics.DrawEllipse(Pens.DeepSkyBlue, p.X - 150, p.Y - 150, 300, 300);
        base.OnPaint(e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        Invalidate();
    }
