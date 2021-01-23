    void chart1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Blue, 2) // dispose of my Pen
              {DashStyle = System.Drawing.Drawing2D.DashStyle.Dot})
           e.Graphics.DrawRectangle(pen, _selectionRectangle);
        foreach (DataPoint point in chart1.Series[0].Points)
        {   // !! officially these functions are only reliable in a paint event!!
            double x = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(point.XValue);
            double y = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(point.YValues[0]);
            PointF pt = new PointF((float)x,(float)y);
            // Check if the data point lies within the rectangle 
            if (_selectionRectangle.Contains(Point.Round(pt)))
            {
                if (!dataPoints.Contains(point)) dataPoints.Add(point);
            }
        }      
    }
