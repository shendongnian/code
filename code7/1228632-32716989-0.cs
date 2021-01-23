    public TestPageDev()
    {
        this.InitializeComponent();
        _view = this.Resources["VM"] as StockVm;
        _view.LoadData();    
        this.DataContext = _view; // here
    }
