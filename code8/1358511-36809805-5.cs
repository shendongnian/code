    void timer_Tick(object sender, EventArgs e)
    {
        Series S1 = chart1.Series[0];
        Series S2 = chart1.Series[1];
        int pointsSoFar = S1.Points.Count;
        if (pointsSoFar < data.Count)
        {
            S1.Points.AddXY(data[pointsSoFar].X, data[pointsSoFar].Y);
            S2.Points.AddXY(data[pointsSoFar].X, data[pointsSoFar].Y);
        }
        else
        {
            timer.Stop();
            chart1.ChartAreas[0].BackColor = Color.AntiqueWhite;
        }
    }
