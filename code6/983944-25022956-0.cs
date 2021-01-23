    // Note that directly after adding points this will return NaN:
    double maxDataPoint = chart1.ChartAreas[0].AxisY.Maximum;
    double minDataPoint = chart1.ChartAreas[0].AxisY.Minimum;
    LineAnnotation annotation2 = new LineAnnotation();
    annotation2.IsSizeAlwaysRelative = false;
    annotation2.AxisX = chart1.ChartAreas[0].AxisX;
    annotation2.AxisY = chart1.ChartAreas[0].AxisY;
    annotation2.AnchorY = minDataPoint;
    annotation2.Height = maxDataPoint - minDataPoint;;
    annotation2.Width = 0;
    annotation2.LineWidth = 2;
    annotation2.StartCap = LineAnchorCapStyle.None;
    annotation2.EndCap = LineAnchorCapStyle.None;
    annotation2.AnchorX = 21;  // <- your point
    annotation2.LineColor = Color.Pink; // <- your color
    chart1.Annotations.Add(annotation2);
