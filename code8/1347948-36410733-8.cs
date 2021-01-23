    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        body0.Add(scaledPoint(e.Location, trackBar1.Value / 100f, true));
        body.Add(e.Location);
        panel1.Invalidate();
    }
