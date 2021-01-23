    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Random R = new Random(13);
        GraphicsPath gp = new GraphicsPath();
        for (int i = 0; i < 23; i++)
        {
            gp.AddLine(R.Next(1234), R.Next(1234), R.Next(1234), R.Next(1234));
            gp.CloseFigure();  // disconnect lines
        }
        RectangleF rect = gp.GetBounds();
        float scale = Math.Min(1f * panel1.Width / rect.Width, 
                               1f * panel1.Height / rect.Height);
        using (Pen penUnscaled = new Pen(Color.Blue, 4f))
        using (Pen penScaled = new Pen(Color.Red, 4f))
        {
            G.Clear(Color.White);
            G.DrawPath(penUnscaled, gp);
            G.ScaleTransform(scale, scale);
            G.TranslateTransform(-rect.X, -rect.Y);
            G.DrawPath(penScaled, gp);
        }
    }
