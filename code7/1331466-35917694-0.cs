    var ds = new EnumerableDataSource<Point>(Collection);
    LineGraph line;
    ds.SetXMapping(x => x.X);
    ds.SetYMapping(y => y.Y);
    line = new LineGraph(ds);
    line.LinePen = new System.Windows.Media.Pen(System.Windows.Media.Brushes.Red, 2);
    //line.Description = new PenDescription("description");
    Graph.Children.Add(line);
    Graph.FitToView();
