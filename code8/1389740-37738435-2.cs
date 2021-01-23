    public MainPage()
    {
        this.InitializeComponent();
        //set the ItemsSource for the ListView
        ItemDetails messageData = new ItemDetails();
        ItemListView.ItemsSource = messageData.Collection;
        ItemListView.SelectedIndex = 0;
    }
