    public UserControl1()
    {
        InitializeComponent();
        this.Loaded += UserControl1_Loaded;
    }
    
    void UserControl1_Loaded(object sender, RoutedEventArgs e)
    {
        LayoutRoot.Height = (this.Parent as CustomMessageBox).ActualHeight;
    }
