    class MainWindowVM
    {
        public RelayCommand<string> WindowCommand { get; set; }
        public MainWindowVM()
        {
              WindowCommand = new RelayCommand<string>(OnWindowCommand);
        }
        private void OnWindowCommand(string obj)
        {
            // obj is the string passed from the Button CommandParameter
        }
    }
