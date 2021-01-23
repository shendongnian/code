    public override void OnAppearing()
    {
        var plotModel = new PlotModel { Title = "OxyPlot Demo" };
    
        plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
        plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });
    
        var series1 = new LineSeries
        {
            MarkerType = OxyPlot.MarkerType.Circle,
            MarkerSize = 4,
            MarkerStroke = OxyPlot.OxyColors.White
        };
    
        series1.Points.Add(new DataPoint(0.0, 6.0));
        series1.Points.Add(new DataPoint(1.4, 2.1));
        series1.Points.Add(new DataPoint(2.0, 4.2));
        series1.Points.Add(new DataPoint(3.3, 2.3));
        series1.Points.Add(new DataPoint(4.7, 7.4));
        series1.Points.Add(new DataPoint(6.0, 6.2));
        series1.Points.Add(new DataPoint(8.9, 8.9));
    
        plotModel.Series.Add(series1);
        Graph.Model = plotModel;
    }
