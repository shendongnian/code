    public ObservableCollection<Order> Orders { get; set; }
    public Order SelectedOrder { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Orders = new ObservableCollection<Order>();
    }
    private void Order_Click(object sender, RoutedEventArgs e)
    {
        SP_Get_OrderItemResult orderRow = gridOrder.SelectedItem as SP_Get_OrderItemResult;
          List<SP_Get_ItemListResult> itemsSource = dbContext.SP_Get_ItemList(orderRow.orderid).ToList();
                for (int i = 0; i < itemsSource.Count(); i++)
                {
                    Orders.Add(new Order(itemsSource[i]));
                }         
    }
