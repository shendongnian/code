    public Control()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(Control_Loaded);
    }
    
    private void Control_Loaded(object sender, RoutedEventArgs e)
    {
        var presenter = FindChild<ScrollContentPresenter>(listView, null);
        var mouseWheelZoom = new MouseWheelZoom(presenter);
        PreviewMouseWheel += mouseWheelZoom.Zoom;
    }
