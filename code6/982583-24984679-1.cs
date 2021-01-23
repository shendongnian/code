    private void timer1_Tick(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
    void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        ang += 2.0 * Math.PI / 180.0;
        var X1 = Convert.ToInt32(X2 - r * Math.Sin(ang));
        var Y1 = Convert.ToInt32(Y2 - r * Math.Cos(ang));
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.DrawLine(
            new Pen(Color.Yellow, 1f),
            new Point(X1, Y1), 
            new Point(X2, Y2 ));
    }
