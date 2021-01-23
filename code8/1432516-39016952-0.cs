    public class MainWindowViewModel
    {
        public ObservableCollection<Address> Addresses { get; } = new ObservableCollection<Address>();
        
        public Address SelectedAddress { //get and set with INotifyPropertyChanged }
        
        public MainWindowViewModel()
        {
            ...
        }
    }
