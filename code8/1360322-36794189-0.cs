    public MainPage()
    {
        this.InitializeComponent();
    
        //Set DataContext for the page
        this.DataContext = new MyCoffee { CoffeeName = "Esperso", Price = 10M };
        //Or for the TextBlock
        //test.DataContext = new MyCoffee { CoffeeName = "Esperso", Price = 10M };
    }
