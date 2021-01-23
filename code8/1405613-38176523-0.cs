    private async void loadData()
    {
        var httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(new Uri("http://domain.com/something.xml"));
        jsonString = await response.Content.ReadAsStringAsync();
        XDocument loadedData = XDocument.Load(jsonString);
    }
    
     public MainPage()
     {
        this.InitializeComponent();
        loadData();
     }
