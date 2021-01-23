    public class Customer
    {
        public customerID;
        public customerName;
        private static object _syncLockOrders = new object();
        .....
        private ObservableCollection<Order> _orderslist;
        public ObservableCollection<Order> orderslist
        {
            get 
            {
                if (_orderslist == null)
                {
                    _orderslist = new ObservableCollection<Order>();
                    BindingOperations.EnableCollectionSynchronization(_ordersList, _syncLockOrders);
                }
                return _orderslist;
            } 
            private set {_orderslist = value;}}
        }
    }
