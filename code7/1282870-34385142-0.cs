    public class CustomersViewModel 
    {
        private readonly IEventAggregator eventAggregator;
        public CustomersViewModel(IEventAggregator eventAggregator) 
        {
            if(eventAggregator==null) 
            {
                throw new ArgumentNullException("eventAggregator");
            }
            this.eventAggregator = eventAggregator;
        }
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set 
            {
                if(selectedCustomer!=value) 
                {
                    selectedCustomer = value;
                    eventAggregator.Publish(new CustomerSelectedEvent(selectedCustomer);
                }
            }
        }
    }
    public class CustomerOrdersViewModel 
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IOrderRepository orderRepository;
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get { return orders; } 
            set 
            {
                if(orders != value)
                {
                    orders = value;
                    OnPropertyChanged("Orders");
                }
            }
        }
        public CustomerDetailViewModel(IEventAggregator eventAggregator, IOrderRepository orderRepository) 
        {
            if(eventAggregator==null) 
            {
                throw new ArgumentNullException("eventAggregator");
            }
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe<CustomerSelectedEvent>(OnCustomerSelected);
            ...
        }
        private async void OnCustomerSelected(CustomerSelectedEvent event) 
        {
            Orders = new ObservableCollection<Order>(await orderRepository.GetOrdersByCustomer(event.Customer.Id);
        }
    }
