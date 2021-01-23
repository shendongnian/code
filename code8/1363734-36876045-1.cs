    public MainWindow()
    {
        InitializeComponent();
        lstOperations = new ObservableCollection<Numbers>();
        lstOperations.CollectionChanged += MyCollectionChanged;
    }
    
    private MyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        dgNumbers.ItemsSource = lstOperations;
    
    }
