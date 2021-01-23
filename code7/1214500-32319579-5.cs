    private int tolerance = 16;
    private const int WM_NCHITTEST = 132;
    private const int HTBOTTOMRIGHT = 17;
    private Rectangle sizeGripRectangle;
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_NCHITTEST:
                base.WndProc(ref m);
                var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                if (sizeGripRectangle.Contains(hitPoint))
                    m.Result = new IntPtr(HTBOTTOMRIGHT);
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
        sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
        region.Exclude(sizeGripRectangle);
        this.panel1.Region = region;
        this.Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
    }
