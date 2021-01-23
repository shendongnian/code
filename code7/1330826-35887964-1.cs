    public MainWindow()
    {
        InitializeComponent();
        Left = System.Windows.SystemParameters.WorkArea.Width - Width;
        Top = System.Windows.SystemParameters.WorkArea.Height - Height;
    }
