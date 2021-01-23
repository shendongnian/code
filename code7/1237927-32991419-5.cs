    private int radius=20;
    [DefaultValue(20)]
    public int Radius
    {
        get { return radius; }
        set
        {
            radius = value;
            this.RecreateRegion();
        }
    }
    private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
        path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
        path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, 
                    radius, radius, 0, 90);
        path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
        path.CloseAllFigures();
        return path;
    }
    private void RecreateRegion()
    {
        var bounds = ClientRectangle;
        bounds.Width--; bounds.Height--;
        using (var path = GetRoundRectagle(bounds, this.Radius))
            this.Region = new Region(path);
        this.Invalidate();
    }
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        this.RecreateRegion();
    }
