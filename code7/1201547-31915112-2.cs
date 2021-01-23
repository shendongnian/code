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
            Orders.Add(new Order(orderRow.orderid));
        }
