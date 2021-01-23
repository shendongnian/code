    var xAxis = new DateTimeAxis
    {
        Position = AxisPosition.Bottom,
        StringFormat = "dd/MM/yyyy",
        Title = "End of Day",
        IntervalLength = 75,
        MinorIntervalType = DateTimeIntervalType.Days,
        IntervalType = DateTimeIntervalType.Days,
        MajorGridlineStyle = LineStyle.Solid,
        MinorGridlineStyle = LineStyle.None,
    };
    
    Plot = new PlotModel { PlotMargins = new OxyThickness(double.NaN, 10, 30, double.NaN) };
    Plot.Axes.Add(xAxis);
