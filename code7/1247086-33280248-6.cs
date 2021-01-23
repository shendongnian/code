    public PlotModel PlotModel { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    
        pv.AddHandler(System.Windows.UIElement.PreviewMouseWheelEvent, new MouseWheelEventHandler(Plot_PreviewMouseWheel), true);
    
        // Create Line series
        var s1 = new LineSeries();
        s1.Points.Add(new DataPoint(2, 7));
        s1.Points.Add(new DataPoint(7, 9));
        s1.Points.Add(new DataPoint(9, 4));
    
        // add Series and Axis to plot model
        PlotModel = new PlotModel();
        PlotModel.Series.Add(s1);
        PlotModel.InvalidatePlot(false);
    }
    
    private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        e.Handled = true;
    }
    private void Plot_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        MessageBox.Show("Plot_PreviewMouseWheel");
    }
