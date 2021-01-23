    public class MasterViewModel : INotifyPropertyChanged
    {
        private Customer _customer;
    
        public Customer Customer 
        { 
            get { return _customer; }
    
            set { _customer = value; RaisePropertyChanged("Customer"); }
        }
        private void RaisePropertyChanged(string propertyName) 
        {
            if (PropertyChanged != null) 
            {
               PropertyChanged(this, new PropertyChangedEventArg(propertyName);
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ChildViewModel : IDisposable
    {
        public ChildViewModel(MasterViewModel masterViewModel)
        {
            _masterViewModel = masterViewModel;
            _masterViewModel.PropertyChanged += OnPropertyChanged;
        }
        public void Dispose() 
        {
            _masterViewModel.PropertyChanged -= OnPropertyChanged;
            _masterViewModel = null;
        }
        private void OnCustomerChanged() 
        {
            MinimizeDemandeCall();
            MinimizeFamilleCall();
            MaximizePostCall();
        }
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           if (e.PropertyName == "Customer") OnCustomerChanged();
        }
    }
