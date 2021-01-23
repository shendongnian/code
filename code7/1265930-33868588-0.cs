    public class ReadAndPrintFromDeviceAsyncCommand : PropertyChangedBase, ICommand
    {
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            private set
            {
                _IsBusy = value;
                NotifyOfPropertyChange();
            }
        }
        public bool CanExecute(object parameter)
        {
            return !IsBusy;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public async void Execute(object parameter)
        {
            IsBusy = true;
            await ...
            IsBusy = false;
        }
    }
