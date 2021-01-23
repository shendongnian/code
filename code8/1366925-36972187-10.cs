    public MainWindow()
    {
        InitializeComponent();
        _state = new State((bool)checkBox.IsChecked);
        this.DataContext = _state;
    }
