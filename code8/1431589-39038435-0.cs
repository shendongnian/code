    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        Axis ay = chart1.ChartAreas[0].AxisY;
        double yMin = chart1.Series[0].Points.Min(x => x.YValues[0]);
        int yMinPix = (int)ay.ValueToPixelPosition(yMin);
        HitTestResult hitr = chart1.HitTest(e.X, yMinPix);
        // now you can do your stuff..    
        Text = hitr.ChartElementType.ToString();
    }
