    public MainPage()
    {
        this.InitializeComponent();
        Loaded += (sender, e) =>
        {
            List<Button> results = new List<Button>();
            FindChildren(results, Hub);
            var mapButton = results.Find(item => item.Name.Equals("mapButton"));
            mapButton.Click += mapButton_Click;
        };
    }
    
    private void mapButton_Click(object sender, RoutedEventArgs arg)
    {
        // Do something...
    }
