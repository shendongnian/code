    class ChangeViewCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;
        public event EventHandler CanExecuteChanged;
        public ChangeViewCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (_mainWindowViewModel.ActiveView.GetType() == typeof(EnterPasswordViewModel))
            {
                _mainWindowViewModel.ActiveView = new ChangePasswordViewModel();
            }
            else
            {
                _mainWindowViewModel.ActiveView = new EnterPasswordViewModel();
            }
        }
    }
