    public class MainWindowViewModel:BaseObservableObject
    {
        public MainWindowViewModel()
        {
            Client = new Customer
            {
                Name = "Steve",
                Friends = new ObservableCollection<string>(new List<string> {"John", "Alex", "Yakov"})
            };
        }
        private Customer _customer;
        public Customer Client
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }
    }
