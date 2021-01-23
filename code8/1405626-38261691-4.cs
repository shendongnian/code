    private void chart2_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Series s = chart1.Series[0];
        ChartArea ca = chart1.ChartAreas[0];
        var pp = s.Points.Select(x=>
            new PointF( (float)ca.AxisX.ValueToPixelPosition(x.XValue),
                        (float)ca.AxisY.ValueToPixelPosition(x.YValues[0])  )   );
        if (s.Points.Count >  1) 
            using (Pen pen = new Pen(Color.DarkOliveGreen, 4f))
                e.ChartGraphics.Graphics.DrawLines(pen, pp.ToArray());
    }
