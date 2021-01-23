    public class MainViewModel : ViewModelBase // <- MVVMLight ViewModel base class
    {
        private string _text = null;
        private bool _isEnabled = true;
        public MainViewModel()
        {
            SaveCommand = new RelayCommand(
                // Execute command
                () => Console.WriteLine(@"Save command received, input value:{0}", Text),
                // Can excute command?
                () => !IsEnabled || (IsEnabled && !string.IsNullOrWhiteSpace(Text)));
        }
        public ICommand SaveCommand { get; set; }
        public string Text
        {
            get { return _text; }
            set { _text = value; RaisePropertyChanged(); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; RaisePropertyChanged(); }
        }
    }
