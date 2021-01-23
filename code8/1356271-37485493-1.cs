    public class Presenter : IPresenter, INotifyPropertyChanged
    {
        private readonly Repository _repository;
        private string _firstName;
        private string _lastName;
        private string _address;
        private Customer _currentCustomer;
        public Presenter(Repository repository)
        {
            _repository = repository;
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address == value) return;
                _address = value;
                OnPropertyChanged();
            }
        }
        public IEnumerable GetCustomers()
        {
            return _repository.GetAllCustomers();
        }
        public void Init()
        {
            var result = _repository.GetAllCustomers();
            SetSelectedCustomer(result[0].Id);
        }
        public void SetSelectedCustomer(int customerId)
        {
            var customer = _repository.GetCustomerById(customerId);
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Address = customer.Address;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
