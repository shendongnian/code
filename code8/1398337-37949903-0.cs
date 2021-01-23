    public DBConnection.Bill Bill { get; set; }
    public Bill_Overview(DBConnection.Bill bill)
    {
        InitializeComponent();
        Bill = bill;
        DataContext = bill;
    }
