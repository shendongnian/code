    public MainWindow()
    {
        InitializeComponent();
            
        this.TimeListView = new ObservableCollection<Item>(new Item[]
            {
                new Item(),
                new Item()
            });
        this.DataContext = this;
    }
    public ObservableCollection<Item> TimeListView
    {
        get;
        private set;
    }
    private void EditClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var item = (Item)button.DataContext;
            
        MessageBox.Show("Item is: " + item.ToString());
    }
