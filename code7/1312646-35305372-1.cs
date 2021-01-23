    using System.Drawing.Drawing2D;
    ..
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle r1 = panel1.ClientRectangle;  // note I don't use width or height!
        Rectangle r2 = new Rectangle(50, 30, 80, 40);
        GraphicsPath gp = new GraphicsPath(FillMode.Alternate);
        gp.AddRectangle(r1);  // first the big one
        gp.AddRectangle(r2);  // now the to exclude
        e.Graphics.FillPath( Brushes.Gold, gp);
    }
