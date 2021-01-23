    public hinoDetail()
    {
        this.InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        hinos result = (e.Parameter as List<hinos>).FirstOrDefault(); //gets the first one only
       textBlock.Text = result.nameHino
    }
    public async void mostraHino()
    {
    }
