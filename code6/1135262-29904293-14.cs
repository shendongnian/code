        List<Point> points = new List<Point>();
        Point lastPoint = Point.Empty;
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            chart1.Invalidate();
        }
        private void chart1_Paint(object sender, PaintEventArgs e)
        {
            // if we have a new point, convert to DataPoint and add to Series.Points:
            if (lastPoint != Point.Empty)
            {
                double dx = chart1.ChartAreas[0].AxisX.PixelPositionToValue(lastPoint.X);
                double dy = chart1.ChartAreas[0].AxisY.PixelPositionToValue(lastPoint.Y);
                chart1.Series[0].Points.AddXY(dx, dy);
            }
            lastPoint = Point.Empty;
            // now recalculate all pixel points:
            points.Clear();
            foreach (DataPoint pt in chart1.Series[0].Points)
            {
                double x = chart1.ChartAreas[0].AxisX.ValueToPixelPosition(pt.XValue);
                double y = chart1.ChartAreas[0].AxisY.ValueToPixelPosition(pt.YValues[0]);
                points.Add(new Point((int)x, (int)y));
            }
            if (points.Count > 1)
                using (Pen pen = new Pen(Color.Red, 2.5f))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    e.Graphics.DrawLines(pen, points.ToArray());
                }
        }
