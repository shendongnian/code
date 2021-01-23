    public MainPage()
    {
        this.InitializeComponent();
        this.DataContext = myChangeCalc;
    }
    
    public ChangeCals myChangeCalc = new ChangeCals { Amountpaid = "111", GoodsCost = "222" };
