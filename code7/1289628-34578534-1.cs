    public MainWindow()
    {
        InitializeComponent();
        // it is a good idea to not allow designer to execute custom code
        if (DesignerProperties.GetIsInDesignMode(this))
           return;
    
        slider.ValueChanged += Slider_ValueChanged;
    }
    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        // do your stuff here
    }
