    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            LoadWindowCommand = new RelayCommand(OnLoadWindowCommand);
        }
        public RelayCommand LoadWindowCommand { get; private set; }
        private void OnLoadWindowCommand()
        {
            Debug.WriteLine("Loaded!");
        }
    }
