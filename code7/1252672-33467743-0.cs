    public hinoDetail()
    {
        this.InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        List<hinos> result = e.Parameter as List<hinos>;
    }
    public async void mostraHino()
    {
    }
