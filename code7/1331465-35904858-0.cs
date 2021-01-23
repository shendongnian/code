    var x = Enumerable.Range(0, 9).Select(i => i * 100.0);
    var y = new double[] { 10, 9, 7, 8, 5, 6, 4, 3, 2, 1 };
    var source = DataSource.Create(x,y);
    var line = plotter.AddLineChart(source)
        .WithStroke(Brushes.Red)
        .WithStrokeThickness(2)
        .WithDescription("x vs y");
