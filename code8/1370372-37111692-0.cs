    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    
    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        WebServiceTransfer.TransferSoapClient tsc = new WebServiceTransfer.TransferSoapClient();
        var response = await tsc.HelloWorldAsync();
        textBlock.Text = response.Body.HelloWorldResult;
    }
