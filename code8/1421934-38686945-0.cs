    private void InitChart()
    {
        System.Windows.Data.Binding indi = new System.Windows.Data.Binding("Case");
        System.Windows.Data.Binding dep = new System.Windows.Data.Binding("Time");
        AreaSeries ares = new AreaSeries();
        ares.ItemsSource = Ready4LOS;
        ares.IndependentValueBinding = dep;
        ares.DependentValueBinding = indi;
    
        DateTimeAxis dta = new DateTimeAxis();
        dta.Interval = 10;
        dta.IntervalType = DateTimeIntervalType.Minutes;
        dta.Title = "Time";
        dta.Orientation = AxisOrientation.X;
        dta.Minimum = DateTime.Now.AddMinutes(-80);
        dta.Maximum = DateTime.Now;
    
        LinearAxis yaxis = new LinearAxis();
        yaxis.Minimum = 0;
        yaxis.Interval = 2;
        yaxis.Title = "Case";
        yaxis.Orientation = AxisOrientation.Y;
    
        chart1.Axes.Add(dta);
        chart1.Axes.Add(yaxis);
        chart1.Series.Add(ares);
    }
