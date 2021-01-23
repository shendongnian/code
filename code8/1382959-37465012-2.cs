    private void chart1_Paint(object sender, PaintEventArgs e)
    {
        // we assume two series variables are set..:
        if (sps1 == null || sps2 == null) return;
        // short references:
        Axis ax = chart1.ChartAreas[0].AxisX;
        Axis ay = chart1.ChartAreas[0].AxisY;
        // now we convert all values to pixels
        List<PointF> points1 =  sps1.Points.Select(x=>
            new PointF((float)ax.ValueToPixelPosition(x.XValue), 
                       (float)ay.ValueToPixelPosition(x.YValues[0]))).ToList();
        List<PointF> points2 =  sps2.Points.Select(x=>
            new PointF((float)ax.ValueToPixelPosition(x.XValue), 
                       (float)ay.ValueToPixelPosition(x.YValues[0]))).ToList();
        // one list forward, the other backward:
        points2.Reverse();
        GraphicsPath gp = new GraphicsPath();
        gp.FillMode = FillMode.Winding;  // the right fillmode
        // it will work fine with either Splines or Lines:
        if (sps1.ChartType == SeriesChartType.Spline )   gp.AddCurve(points1.ToArray());
        else gp.AddLines(points1.ToArray());
        if (sps2.ChartType == SeriesChartType.Spline) gp.AddCurve(points2.ToArray());
        else gp.AddLines(points2.ToArray()); 
        // pick your own color, maybe a mix of the Series colors..
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(66, Color.DarkCyan)))
            e.Graphics.FillPath(brush, gp);
        gp.Dispose();
    }
