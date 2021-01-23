    private Receipt _myReceipt;
    public Receipt MyReceipt { get { return _myReceipt; } set { _myReceipt = value; OnPropertyChanged("MyReceipt"); } } 
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        MyReceipt = new Receipt { ReceiptPositions = new ObservableCollection<ReceiptPosition>() };
            
        MyReceipt.ReceiptPositions.Add(new ReceiptPosition { Article = "Foo" });
        MyReceipt.ReceiptPositions.Add(new ReceiptPosition { Article = "Bar" });
        MyReceipt.ReceiptPositions.Add(new ReceiptPosition { Article = "Baz" });
        MyReceipt.ReceiptPositions[0].Article = "Frabazamataz";
    }
