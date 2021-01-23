    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        double yOffset = GetYOffset(chart1, e.X);
        Point mousePoint = new Point(e.X, yOffset);
        chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint,false);
        chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint,false);
    }
    // ChartClass chart is just whatever chart you're using
    // x is used here I'm assuming to find f(x), your value
    private double GetYOffset(ChartClass chart, double x)
    {
        double yOffset;
        // yOffset = height * (rangeMax - value) / (rangeMax - rangeMin);
        return yOffset;
    }
