    public class ClientRateViewModel
    {
        public string Description { get; set; }
        public int Value { get; set; }
    }
    public class RelayCommand : ICommand
    {
        Action<object> _execute;
        public RelayCommand(Action<object> execute) {
            _execute = execute;
        }
        public void Execute(object parameter) {
            _execute(parameter);
        }
        public bool CanExecute(object parameter) {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
    public class ViewModel
    {
        public ViewModel() {
            ClientRatesPostAwr = new List<ClientRateViewModel>();
            ClientRatesPostAwr.Add(new ClientRateViewModel { Description = "description 1", Value = 1 });
            ClientRatesPostAwr.Add(new ClientRateViewModel { Description = "description 2", Value = 2 });
            SaveCommand = new RelayCommand((o) => {
                MessageBox.Show("Saving: " + string.Join(",", ClientRatesPostAwr.Select(cr => cr.Value.ToString())));
            });
        }
        public IList<ClientRateViewModel> ClientRatesPostAwr { get; private set; }
        public ICommand SaveCommand { get; private set; }
    }
