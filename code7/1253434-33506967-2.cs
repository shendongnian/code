    public MainWindow()
    {
        InitializeComponent();
        //StockEngine control = new StockEngine();
    
        var products = new List<Product>();
    
        Product p1 = new Product("1001", "Product1", 10, 5);
        Product p2 = new Product("1002", "Product2", 6, 5);
        Product p3 = new Product("1003", "Product3", 8, 5);
        Product p4 = new Product("999", "Some Prod", 8, 5);
        Product p5 = new Product("1002", "Product4", 10, 10);
    
        products.Add(p1);
        products.Add(p2);
        products.Add(p3);
        products.Add(p4);
        products.Add(p5);
    
        ListView.ItemsSource = products;
    }
