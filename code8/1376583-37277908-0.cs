     private void Form1_Load(object sender, EventArgs e)
        {
            int xmax = 100;
            chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 50;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = 50;
            chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 50;
            for (int x = 1; x < xmax; x++)
                chart1.Series[0].Points.AddXY(x, 5 * x);
        }
