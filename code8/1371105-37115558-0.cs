    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (chart1.Series.Count == 0) return;
        Axis AX = chart1.ChartAreas[0].AxisX;
        Axis AY = chart1.ChartAreas[0].AxisY;
        chart1.ApplyPaletteColors();
        foreach (Series s in chart4.Series)
            foreach (DataPoint dp in s.Points)
            {
               int x = (int)AX.ValueToPixelPosition(dp.XValue);
               int y = (int)AY.ValueToPixelPosition(dp.YValues[0]);
               int w2 = 4;
               using (SolidBrush brush = new SolidBrush(Color.YellowGreen))
                      e.ChartGraphics.Graphics.FillEllipse(brush, 
                                                           x - w2, y - w2, w2 * 2, w2 * 2);
            }
    }
