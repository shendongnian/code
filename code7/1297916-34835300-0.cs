            var original = chart1.Series.Add("Original");
            var modified = chart1.Series.Add("Modified");
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.Series["Original"].Points.AddXY("CPU", 7.6);
            chart1.Series["Modified"].Points.AddXY("CPU", 1.6);
