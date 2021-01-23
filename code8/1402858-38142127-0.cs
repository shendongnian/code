    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            ...
            LoadCostumersAsync(); //code after this line executes before LoadCostumersAsync() is finished, so your UI remains responsive
            ...
        }
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers { get { return _customers; } }
        private async void LoadStopsAsync()
        {
            IsLoading= true; // you can use this property to show a busyindicator on the UI
            _customers = await LoadCostumers; 
            IsLoading = false;
        }
        public System.Threading.Tasks.Task<ObservableCollection<Customer>> LoadCostumers()
        {
            return System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                return YourMethodThatGetsCostumers();
            });
        }
    }
