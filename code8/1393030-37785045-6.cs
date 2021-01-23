    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (checkBox1.Checked) return;
        ChartArea ca = chart1.ChartAreas[0];
        RectangleF ipar = InnerPlotPositionClientRectangle(chart1, ca);
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        Color gc = ax.MajorGrid.LineColor;
        Pen pen = new Pen(gc); 
        double ix = ax.Interval == 0 ? 1 : ax.Interval;  // best make sure to set..
        double iy = ay.Interval == 0 ? 50 : ay.Interval; // ..the intervals!
        for (double vx = ax.Minimum; vx <= ax.Maximum; vx+= ix)
        {
            int x = (int)ax.ValueToPixelPosition(vx);
            e.ChartGraphics.Graphics.DrawLine(pen, x, ipar.Top, x, ipar.Bottom);
        }
        for (double vy = ay.Minimum; vy <= ay.Maximum; vy += iy)
        {
            int y = (int)ay.ValueToPixelPosition(vy);
            e.ChartGraphics.Graphics.DrawLine(pen, ipar.Left, y, ipar.Right, y);
        }
    }
