    public Form1()
    {
        InitializeComponent();
        StringFormat fmt = new StringFormat();
        fmt.Alignment = StringAlignment.Near;
        using (FontFamily ff = new FontFamily("Times"))
            gp.AddString("CRY", ff, 1, 400, Point.Empty, fmt);
    }
     GraphicsPath gp = new GraphicsPath();
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawPath(Pens.Red, gp);
        List<Brush> br = new List<Brush>() 
        {Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Violet,
         Brushes.DarkKhaki, Brushes.DarkCyan, Brushes.Chocolate};
        int cc = 0;
        if (gp != null && gp.PathPoints != null && gp.PathPoints.Length > 1)
        for (int i = 0; i < gp.PathPoints.Length; i++)
        {
            PointF pt = gp.PathPoints[i];
            int  ptype = gp.PathTypes[i];
            if (ptype != 3) cc = 0; else cc++;
            if (ptype > 3) ptype = 4;
            e.Graphics.FillEllipse(br[ptype + cc % 3], pt.X - 3, pt.Y - 3, 6, 6 );
        }
    }
