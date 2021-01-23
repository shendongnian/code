    public MainWindow()
    {
    InitializeComponent();
    plotter.Viewport.Domain = new Rect(-1, -1.2, 20, 2.4);
    plotter.Children.Add(new HorizontalScrollBar());
    plotter.AxisGrid.DrawHorizontalMinorTicks = false;
    plotter.AxisGrid.DrawVerticalMinorTicks = false;
            
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
    lineGraph.DataSource = CreateSineDataSource(1.0);
    }   
    private IPointDataSource CreateSineDataSource(double phase)
    {
    const int N = 100;
    Point[] pts = new Point[N];
    for (int i = 0; i < N; i++)
    {
    double x = i / (N / 10.0) + phase;
    pts[i] = new Point(x, Math.Sin(x - phase));
    }
    var ds = new EnumerableDataSource<Point>(pts);
    ds.SetXYMapping(pt => pt);
    return ds;
    }
