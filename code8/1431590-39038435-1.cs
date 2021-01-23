    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        Axis ay = chart1.ChartAreas[0].AxisY;
        int zeroPix = (int)ay.ValueToPixelPosition(0);
        HitTestResult hittr = chart1.HitTest(e.X, zeroPix );
        // now you can do your stuff..    
        Text = hittr.ChartElementType.ToString();
    }
