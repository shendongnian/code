    GraphicsPath GP = null;
    List<Point> points = new List<Point>();
        
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        points.Clear();
        points.Add(e.Location);
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        GP = new GraphicsPath();
        GP.AddClosedCurve(points.ToArray());
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            points.Add(e.Location);
            pictureBox1.Invalidate();
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (points.Count > 1)
            e.Graphics.DrawCurve(Pens.Orange, points.ToArray(), 0.5f);
    }
    private void cb_clearRegion_Click(object sender, EventArgs e)
    {
        points.Clear();
        pictureBox1.Region = null;
    }
    private void cb_SaveRegion_Click(object sender, EventArgs e)
    {
        Rectangle cr = pictureBox1.ClientRectangle;
        using (Bitmap bmp = new Bitmap(cr.Width, cr.Height))
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.SetClip(GP);
            G.DrawImage(pictureBox1.Image, Point.Empty);
            bmp.Save(@"D:\xyz.png", ImageFormat.Png);
        }
    }
