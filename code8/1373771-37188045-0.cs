    public UserControl()
    {
        InitializeComponent();
    }
    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        window.Close();
    }
