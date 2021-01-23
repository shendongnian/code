    void aTimer_Tick(object sender, EventArgs e)
    {
        point = Math.Min(point + 1, way.Count);
        pictureBox1.Invalidate();
        if (point >= way.Count) aTimer.Stop();
    }
