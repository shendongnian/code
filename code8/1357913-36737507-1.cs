    public MainPage()
    {
        this.InitializeComponent();
        listViewItems.Source = Headers.GetItemsGrouped();
    }
