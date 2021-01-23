    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        HitTestResult hit = chart1.HitTest(e.X, e.Y);
        if (hit.PointIndex >= 0)
            infoLabel.Text = "Over DataPoint No " +  hit.PointIndex;
    }
