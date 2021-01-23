    public MainWindow()
    {
        InitializeComponent();
        // auto-size width, and save off value
        this.SizeToContent = System.Windows.SizeToContent.Width;
        var actualWidth = this.ActualWidth;
        // manual-size width
        this.SizeToContent = System.Windows.SizeToContent.Manual;
        // set value to what it was, when auto-sized
        this.Width = actualWidth;
    }
