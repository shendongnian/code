    PointF PolarValueToPixelPosition(DataPoint dp, Chart chart, ChartArea ca)
    {
        RectangleF ipp = InnerPlotPositionClientRectangle(chart, ca);
        double crossing = ca.AxisX.Crossing != double.NaN ? ca.AxisX.Crossing : 0;
        // for RangeChart change 90 zo 135 !
        float phi = (float)(360f / ca.AxisX.Maximum / 180f * Math.PI *   
                 (dp.XValue - 90 + crossing ) );
        float yMax = (float)ca.AxisY.Maximum;
        float yMin = (float)ca.AxisY.Minimum;
        float radius = ipp.Width / 2f;
        float len = (float)(dp.YValues[0] - yMin) / (yMax - yMin);
        PointF C = new PointF(ipp.X + ipp.Width / 2f, ipp.Y + ipp.Height / 2f);
        float xx = (float)(Math.Cos(phi) * radius * len);
        float yy = (float)(Math.Sin(phi) * radius * len); 
        return new PointF(C.X + xx, C.Y + yy);
    }
