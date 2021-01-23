    public class ViewModel
    {
        private ObservableCollection<Customer> _customercollection;
    
        private void LoadCustomers()
        {
            _customercollection = // load customers somehow;
            ActiveCustomers = new ListCollectionView(_customercollection)
            {
                Filter = c => ((Customer)c).IsActive
            };
            OnPropertyChanged("ActiveCustomers");
     
            // almost the same code for SuspendedCustomers and ResignedCustomers
        }
    
        public ICollectionView ActiveCustomers { get; private set; }
        private ICollectionView SuspendedCustomers { get; private set; }
        private ICollectionView ResignedCustomers { get; private set; }
    
        // rest of code
    }
