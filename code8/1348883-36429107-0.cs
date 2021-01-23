        private void Form1_Load(object sender, EventArgs e)
        {
            string series = "TestData";
            // Clear Series
            chart.Series.Clear();
            // Add new Sereis and set XValueType
            chart.Series.Add(series);
            chart.Series[series].XValueType = ChartValueType.Date;
            chart.Series[series].IsXValueIndexed = true;
            // Add data points to Series
            chart.Series[series].Points.AddXY(new DateTime(2008, 1, 1).ToOADate(), 49.91);
            chart.Series[series].Points.AddXY(new DateTime(2009, 1, 1).ToOADate(), 102.05);
            chart.Series[series].Points.AddXY(new DateTime(2010, 1, 1).ToOADate(), 15.84);
            chart.Series[series].Points.AddXY(new DateTime(2011, 1, 1).ToOADate(), 29.12);
            chart.Series[series].Points.AddXY(new DateTime(2012, 1, 1).ToOADate(), 3.3);
            chart.Series[series].Points.AddXY(new DateTime(2013, 1, 1).ToOADate(), 31.09);
            chart.Series[series].Points.AddXY(new DateTime(2014, 1, 1).ToOADate(), 5.44);
            // Set color and dash style of Major Grid
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            // Set Interval for X-Axis
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
            chart.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Years;            
                                    
        }
