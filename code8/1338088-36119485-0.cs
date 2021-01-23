    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        if (e.ChartElement == "ChartArea-ChartArea1")
        {
            // get the positions of the axixs' ends:
            float xx = (float)chart1.ChartAreas[0].AxisX.ValueToPixelPosition(100);
            float xy = (float)chart1.ChartAreas[0].AxisY.ValueToPixelPosition(0);
            float yx = (float)chart1.ChartAreas[0].AxisX.ValueToPixelPosition(0);
            float yy = (float)chart1.ChartAreas[0].AxisY.ValueToPixelPosition(100);
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
