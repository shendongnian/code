    GraphicsPath GP = new GraphicsPath();
    private void button1_Click(object sender, EventArgs e)
    {
        Rectangle R1 = new Rectangle(10, 20, 40, 200);
        Rectangle R2 = new Rectangle(20, 10, 200, 40);
        Rectangle Rgap = new Rectangle(Math.Min(R1.X, R2.X), Math.Min(R1.Y, R2.Y),
                     2 * Math.Abs( R1.Left - R2.Left), 2 * Math.Abs(  R2.Top - R1.Top) );
        GP.AddRectangle(R1);
        GP.AddRectangle(R2);
        
        // pick one of these arcs:
        GP.AddArc(Rgap, 0, 360);    // full ellipse, simplest, if you have the space
        // GP.AddArc(Rgap, 0, 90);     // bottom right
        // GP.AddArc(Rgap, 90, 90);    // bottom left
        // GP.AddArc(Rgap, 180, 90);   // top left
        // GP.AddArc(Rgap, 270, 90);   // top right
        
        // if you draw only a quarter elipse you need to add a triagle to fill the rest
        // here is only the code for the top left, the others will be different but similar: 
        GP.AddPolygon(new Point[] { R1.Location, R2.Location, 
                      new Point(R1.Left + Rgap.Width / 2, R2.Top + Rgap.Height / 2) });
        GP.FillMode = FillMode.Winding;
        aPanel.Invalidate();
    }
    private void aPanel_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Black, 1.5f))
        {
            e.Graphics.DrawPath(pen, GP);
            e.Graphics.FillPath(Brushes.Red, GP);
        }
    }
