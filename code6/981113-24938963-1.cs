    var xAxis = new DateTimeAxis
    {
        Position = AxisPosition.Bottom,
        StringFormat = Constants.MarketData.DisplayDateFormat,
        Title = "End of Day",
        IntervalLength = 75,
        MinorIntervalType = DateTimeIntervalType.Days,
        IntervalType = DateTimeIntervalType.Days,
        MajorGridlineStyle = LineStyle.Solid,
        MinorGridlineStyle = LineStyle.None,
    };
    
    var yAxis = new LinearAxis
    {
        Position = AxisPosition.Left,
        Title = "Value",
        MajorGridlineStyle = LineStyle.Solid,
        MinorGridlineStyle = LineStyle.None
    };
    
    var plot = new PlotModel();
    plot.Axes.Add(xAxis);
    plot.Axes.Add(yAxis);
    
    var circlePoints = new[]
    {
        new ScatterPoint(DateTimeAxis.ToDouble(date1), value1),
        new ScatterPoint(DateTimeAxis.ToDouble(date2), value2),
    };
    
    var circleSeries =  new ScatterSeries
    {
        MarkerSize = 7,
        MarkerType = MarkerType.Circle,
        ItemsSource = circlePoints
    };
                
    var linePoints = new[]
    {
        new DataPoint(DateTimeAxis.ToDouble(date1), value1),
        new DataPoint(DateTimeAxis.ToDouble(date2), value2),
    };
                
    var lineSeries = new LineSeries
    {
        StrokeThickness = 2,
        Color = LineDataPointColor,
        ItemsSource = linePoints
    };
    
    plot.Series.Add(circleSeries);
    plot.Series.Add(lineSeries);
