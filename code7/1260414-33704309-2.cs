    public class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
    
        private static CustomerRepository _customerRepository;
    
        // existing constructor
        public MainViewModel(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // new parameterless constructor
        public MainViewModel(CustomerRepository customerRepository)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                _customerRepository = new CustomerRepository();         
            }
        }
    }
