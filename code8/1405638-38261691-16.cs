    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Chart  chart = chart1;
        Series s0 = chart.Series[0];
        ChartArea ca = chart.ChartAreas[0];
        // calculate width of a bar:
        int pp1 = (int)ca.AxisX.ValueToPixelPosition(s0.Points[0].XValue);
        int pp2 = (int)ca.AxisX.ValueToPixelPosition(s0.Points[1].XValue);
        float delta = Math.Abs(pp2 - pp1) / 2f;
        for (int s = 0; s < chart.Series.Count; s++)
        {
           List<PointF> points = new List<PointF>();
           for (int p = 0; p < chart.Series[s].Points.Count; p++)
           {
             DataPoint dp = chart.Series[s].Points[p];
             double v = GetStackTopValue(chart, s, p);
             points.Add(new PointF((float)ca.AxisY.ValueToPixelPosition(v),
                                    (float)ca.AxisX.ValueToPixelPosition(dp.XValue) + delta));
             points.Add(new PointF((float)ca.AxisY.ValueToPixelPosition(v),
                                   (float)ca.AxisX.ValueToPixelPosition(dp.XValue) - delta));
            }
            using (Pen pen = new Pen(Color.DarkOliveGreen, 3f))
                e.ChartGraphics.Graphics.DrawLines(pen, points.ToArray());
        }
    }
    double GetStackTopValue(Chart chart, int series, int point)
    {
        double v = 0;
        for (int i = 0; i < series + 1; i++)
            v += chart.Series[i].Points[point].YValues[0];
        return v;
    }
