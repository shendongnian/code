    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        foreach (Line L in lines) L.Draw(e.Graphics);
    }
