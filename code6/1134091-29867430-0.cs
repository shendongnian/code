    public MainWindow()
    {
        InitializeComponent();
        Closing += OnClosing;
    }
    private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
    {
        if (MessageBox.Show(this, "Your message", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
        {
            cancelEventArgs.Cancel = true;
        }
    }
