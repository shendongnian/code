    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (mFullSize) return; // just don't paint the things you don't want to
        Graphics gr = e.Graphics;
        int x = 50;
        int y = 50;
        int width = 100;
        int height = 100;
        Rectangle rect = new Rectangle(x, y, width / 2, height / 2);
        Region region = new Region(rect);
        GraphicsPath path = new GraphicsPath();
        path.AddPie(x, y, width, height, 180, 90);
        region.Exclude(path);
        gr.FillRegion(Brushes.Black, region);
    }
