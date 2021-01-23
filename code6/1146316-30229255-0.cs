    private void button1_Click(object sender, EventArgs e)
    {
        Random rdn = new Random();
        for (int i = 116; i > 0; i--)
        {
            chart1.Series["Series1"].Points.AddXY
                (rdn.Next(0, 10), rdn.Next(0, 10));
        }
        chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
        chart1.Series["Series1"].Color = Color.Red;
        ChartArea area = chart1.ChartAreas[0];
        // Set the min and max for each axis
        area.AxisX.Minimum = 1;
        area.AxisX.Maximum = 30;
        area.AxisY.Minimum = 1;
        area.AxisY.Maximum = 116;
        // Add a line on top of the chart
        LineAnnotation line = new LineAnnotation();
        chart1.Annotations.Add(line);
        // Set the annotation positioning to be relative to the X and Y axes
        line.AxisX = area.AxisX;
        line.AxisY = area.AxisY;
        // Set the actual annotation position and boundary. Disable
        // IsSizeAlwaysRelative so that the annotation's size is
        // determined by the absolute positioning of the boundary.
        line.IsSizeAlwaysRelative = false;
        line.X = 1; line.Y = 116;
        line.Right = 30; line.Bottom = 1;
        // Format the line so it shows up better
        line.LineColor = Color.Blue;
        line.LineWidth = 3;
    }
