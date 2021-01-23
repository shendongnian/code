    GraphicsPath GP = new GraphicsPath();
    private void button1_Click(object sender, EventArgs e)
    {
        Rectangle R1 = new Rectangle(10, 20, 40, 200);
        Rectangle R2 = new Rectangle(20, 10, 200, 40);
        // the top left gap
        Rectangle TopLeftGap = 
              new Rectangle(Math.Min(R1.Left, R2.Left), Math.Min(R1.Top, R2.Top),
                  2 * Math.Abs(R1.Left - R2.Left), 2 * Math.Abs(R1.Top - R2.Top));
        // the top right  gap
        Rectangle TopRightGap = 
              new Rectangle(Math.Max(R1.Right, R2.Right), Math.Min(R1.Top, R2.Top),
                 2 * Math.Abs(R1.Left - R2.Left), 2 * Math.Abs(R1.Top - R2.Top));
        // the bottom right  gap
        Rectangle BottomRightGap = 
              new Rectangle(Math.Max(R1.Right, R2.Right), Math.Max(R1.Bottom, R2.Bottom),
                  2 * Math.Abs(R1.Right - R2.Right), 2 * Math.Abs(R1.Bottom - R2.Bottom));
        // the bottom left  gap
        Rectangle BottomLeftGap = 
              new Rectangle(Math.Min(R1.Left, R2.Left), Math.Max(R1.Bottom, R2.Bottom),
                  2 * Math.Abs(R1.Left - R2.Left), 2 * Math.Abs(R1.Bottom - R2.Bottom));
        Rectangle Rgap = TopLeftGap; 
        GP.AddRectangle(R1);
        GP.AddRectangle(R2);
        
        // pick one of these arcs:
        GP.AddArc(Rgap, 0, 360);    // full ellipse, simplest, if you have the space
        // GP.AddArc(Rgap, 0, 90);     // bottom right
        // GP.AddArc(Rgap, 90, 90);    // bottom left
        // GP.AddArc(Rgap, 180, 90);   // top left
        // GP.AddArc(Rgap, 270, 90);   // top right
        
        // If you draw only a quarter ellipse you need to add a triangle 
        // to fill the rest of the gap
        // here is only the code for the top left, the others will be different: 
        // GP.AddPolygon(new Point[] { R1.Location, R2.Location, 
        //              new Point(R1.Left + Rgap.Width / 2, R2.Top + Rgap.Height / 2) });
        GP.FillMode = FillMode.Winding;
        aPanel.Invalidate();
    }
    private void aPanel_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Black, 2f))
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawPath(pen, GP);
            e.Graphics.FillPath(Brushes.Red, GP);
        }
    }
