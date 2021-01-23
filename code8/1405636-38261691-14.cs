    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Series s = chart1.Series[0];
        ChartArea ca = chart1.ChartAreas[0];
        if (s.Points.Count <= 0) return;
        // calculate width of a column:
        int pp1 = (int)ca.AxisX.ValueToPixelPosition(s.Points[0].XValue);
        int pp2 = (int)ca.AxisX.ValueToPixelPosition(s.Points[1].XValue);
        float w2 = Math.Abs(pp2 - pp1) / 2f;
        List<PointF> points = new List<PointF>();
        for (int i = 0; i < s.Points.Count; i++)
        {
            DataPoint dp = s.Points[i];
            points.Add(new PointF( (int)ca.AxisX.ValueToPixelPosition(dp.XValue) - w2,
                                   (int)ca.AxisY.ValueToPixelPosition(dp.YValues[0]) ));
            points.Add(new PointF( (int)ca.AxisX.ValueToPixelPosition(dp.XValue) + w2,
                                   (int)ca.AxisY.ValueToPixelPosition(dp.YValues[0]) ));
        }
        if (points.Count > 1)
            using (Pen pen = new Pen(Color.DarkOliveGreen, 4f))
                e.ChartGraphics.Graphics.DrawLines(pen, points.ToArray());
    }
