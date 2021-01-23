    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        if (e.ChartElement.ToString().StartsWith("ChartArea-") )
        {
            // get the positions of the axixs' ends:
            ChartArea CA = chart1.ChartAreas[0];
            float xx = (float)CA.AxisX.ValueToPixelPosition(CA.AxisX.Maximum);
            float xy = (float)CA.AxisY.ValueToPixelPosition(CA.AxisY.Crossing);
            float yx = (float)CA.AxisX.ValueToPixelPosition(CA.AxisX.Crossing);
            float yy = (float)CA.AxisY.ValueToPixelPosition(CA.AxisY.Maximum);
            // a simple arrowhead geometry:
            int arrowSize = 18;   // size in pixels
            Point[] arrowPoints = new Point[3]   { new Point(-arrowSize, -arrowSize / 2), 
                 new Point(-arrowSize, arrowSize / 2), Point.Empty };
            // draw the two arrows by moving and/or rotating the graphics object:
            e.ChartGraphics.Graphics.TranslateTransform(xx + arrowSize, xy);
            e.ChartGraphics.Graphics.FillPolygon(Brushes.Black, arrowPoints);
            e.ChartGraphics.Graphics.TranslateTransform(yx -xx -arrowSize, yy -xy -arrowSize);
            e.ChartGraphics.Graphics.RotateTransform(-90);
            e.ChartGraphics.Graphics.FillPolygon(Brushes.Black, arrowPoints);
            e.ChartGraphics.Graphics.ResetTransform();
        }
    }
