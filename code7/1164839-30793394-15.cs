    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.DrawLines(Pens.Red, points.ToArray());
        e.Graphics.DrawCurve(Pens.Green, points.ToArray());
        e.Graphics.DrawCurve(Pens.Blue, points.ToArray(), 0.1f);
    }
