    private void showchart(object sender, EventArgs e)
    {
        var reading = new Reading{ 
            A = sensor.Substring(4,3),
            B = sensor.Substring(10,3),
            CreationDate = DateTime.Now
        };
        readings.Add(reading);
        
        var test1Series =  chart1.Series["test1"];
        var test2Series =  chart1.Series["test2"];
       
        System.Diagnostics.Debug.WriteLine(
             "{0} {1} {2}", 
            reading.A,
            reading.B,
            reading.CreationDate);
        test1Series.Points.AddXY(0, reading.A);
        test2Series.Points.AddXY(0, reading.B);
        if ((test1Series.Points.Count > 20) && 
            (test2Series.Points.Count > 20))
        {
            test1Series.Points.RemoveAt(0);
            test2Series.Points.RemoveAt(0);
        }
        // you only need this once, consider moving it to an init method
        test1Series.ChartType = SeriesChartType.Spline;
        test1Series.Color = Color.DarkOrange;
        test2Series.ChartType = SeriesChartType.Spline;
        test2Series.Color = Color.DarkMagenta;
    }
