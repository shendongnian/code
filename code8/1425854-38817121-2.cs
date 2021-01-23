    public class CustomerViewModel
    {
        public ObservableCollection<Customer> CustomerCollection { get; set; }
        public CustomerViewModel()
        {
            CustomerCollection = new ObservableCollection<Customer>();
        }
    }
