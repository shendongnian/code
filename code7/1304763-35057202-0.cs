    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += Page_Loaded;
    }
    
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        txt2.Focus(FocusState.Keyboard);
    }
