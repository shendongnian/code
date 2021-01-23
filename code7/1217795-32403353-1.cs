    public class Customer
    {
        public customerID;
        public customerName;
        public object _syncLockOrders = new object();
        .....
        private ObservableCollection<Order> _orderslist;
        public ObservableCollection<Order> orderslist
        {
            get 
            {
                if (_orderslist == null)
                {
                    _orderslist = new ObservableCollection<Order>();
                }
                return _orderslist;
            } 
            private set {_orderslist = value;}}
        }
    }
    public class MainWindow : Window
    {
        ...
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var firstCustomer = Customers.customerslist.FirstOrDefault();
            custDataGrid.DataContext = Customers.customerslist;
            if (firstCustomer != null)
            {
                custDataGrid.SelectedItem = firstCustomer;
                ordersDataGrid.DataContext = firstCustomer.Orders.orderslist;
            } 
     ....
            BindingOperations.EnableCollectionSynchronization(firstCustomer.ordersList, firstCustomer._syncLockOrders);
    }
