    PlotModel model = new PlotModel();
    List<DataPoint> Points = new List<DataPoint>();
    LineSeries lineserie = new LineSeries
    {
        ItemsSource = Points,
        DataFieldX = "x",
        DataFieldY = "Y",
        StrokeThickness = 2,
        MarkerSize = 0,
        LineStyle = LineStyle.Solid,
        Color = OxyColors.White,
        MarkerType = MarkerType.None,
    };
    model.Series.Add(lineserie);
