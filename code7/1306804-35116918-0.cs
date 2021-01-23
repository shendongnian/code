    public MainPage()
    {
        this.InitializeComponent();
        // rest of code
        this.Loaded += MainPage_Loaded;
    }
    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        string mitarbeiterListe = await getContentOfSendOperation();
    }
