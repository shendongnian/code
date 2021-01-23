    GraphicsPath GP = new GraphicsPath();
    private void button1_Click(object sender, EventArgs e)
    {
        Rectangle R1 = new Rectangle(10, 20, 40, 200);
        Rectangle R2 = new Rectangle(20, 10, 200, 40);
        Rectangle Rgap = new Rectangle(Math.Min(R1.X, R2.X), Math.Min(R1.Y, R2.Y),
                         2 * Math.Abs( R1.Left - R2.Left), 2 * Math.Abs(  R2.Top - R1.Top) );
        GP.AddRectangle(R1);
        GP.AddRectangle(R2);
        GP.AddArc(Rgap, 270, 360);  //  <-- this is for a top left corner only! 
        GP.FillMode = FillMode.Winding;
        aPanel.Invalidate();
    }
    private void aPanel_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.DarkOrange, 1.5f))
        {
            GraphicsPath GP2 = (GraphicsPath) GP.Clone();
            GP2.Widen(pen);
            e.Graphics.DrawPath(pen, GP2);
            e.Graphics.FillPath(Brushes.Beige, GP);
        }
    }
