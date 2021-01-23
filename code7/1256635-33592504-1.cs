    public GridLength TestGridLength
    {
        get { return (GridLength)GetValue(TestGridLengthProperty); }
        set { SetValue(TestGridLengthProperty, value); }
    }
            
    public static readonly DependencyProperty TestGridLengthProperty =
        DependencyProperty.Register(
            "TestGridLength",
            typeof(GridLength),
            typeof(MainPage),
            new PropertyMetadata(null));
    
    
    public MainPage()
    {
        this.InitializeComponent();
        this.TestGridLength = new GridLength(10, GridUnitType.Star);
    }
