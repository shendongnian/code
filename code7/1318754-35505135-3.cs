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
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Main = new MainWindowViewModel();
        }
        public MainWindowViewModel Main { get; private set; }
    }
