    public class MainWindowViewModel:BaseViewModel
    {
        public MainWindowViewModel()
        {
            _customerOrders = new List<OrderModel>();
            _customerOrders.Add(new OrderModel(){Date = DateTime.Now, Email = "mymail@gmail.com", Status = "Active"});
            InitializeAsync();
        }
        private List<OrderModel> _customerOrders;
        private OrderModel _selectedOrder;
        public List<OrderModel> CustomerOrders
        {
            get { return this._customerOrders; }
            set
            {
                _customerOrders = value;
                OnPropertyChanged("CustomerOrders");
            }
        }
        public OrderModel SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        private async void InitializeAsync()
        {
            CustomerOrders = await LoadCustomerOrdersAsync();
        }
        private async Task<List<OrderModel>> LoadCustomerOrdersAsync()
        {
           return await Task.Run(() => new List<OrderModel>()
           {
               new OrderModel() {Date = DateTime.Now, Email = "mymail1@gmail.com", Status = "Active"},
               new OrderModel() {Date = DateTime.Now, Email = "mymail2@gmail.com", Status = "Active"},
               new OrderModel() {Date = DateTime.Now, Email = "mymail3@gmail.com", Status = "Active"},
               new OrderModel() {Date = DateTime.Now, Email = "mymail4@gmail.com", Status = "Active"},
               new OrderModel() {Date = DateTime.Now, Email = "mymail5@gmail.com", Status = "Active"},
               new OrderModel() {Date = DateTime.Now, Email = "mymail6@gmail.com", Status = "Active"},
           });
        }
    }
