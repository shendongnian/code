    GraphicsPath GP = new GraphicsPath();
    private void button1_Click(object sender, EventArgs e)
    {
        GP.AddRectangle(new Rectangle(10,20,40,200));
        GP.AddRectangle(new Rectangle(20,10,200,40));
        GP.AddEllipse(new Rectangle(10,10,20,20));  // 10, 10, 40-20, 40-20 
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
