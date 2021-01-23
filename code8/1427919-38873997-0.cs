    double PercentFromValue(Chart chart, ChartArea ca, double value)
    {
        Axis ay = ca.AxisY;
        RectangleF car = ca.Position.ToRectangleF();
        double py = ay.ValueToPixelPosition(value);
        int caHeight = (int)(chart.ClientRectangle.Height * car.Height / 100f);
        return 100d * py / caHeight;
    }
