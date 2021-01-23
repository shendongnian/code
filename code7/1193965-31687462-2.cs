    namespace WpfApplication1
    {
        public class ButtonViewModel : INotifyPropertyChanged
        {
            private bool _isEnabled;
            private ViewModel _viewModel;
    
            public bool IsEnabled
            {
                get { return _isEnabled; }
                set
                {
                    _isEnabled = value;
                    OnPropertyChanged();
                }
            }
    
            public int SubtractAmount { get; set; }
    
            public ICommand SubtractCommand { get; private set; }
    
            public ButtonViewModel(ViewModel viewModel)
            {
                _viewModel = viewModel;
                IsEnabled = true;
    
                SubtractCommand = new CommandHandler(() =>
                {
                    _viewModel.CurrentAmount -= SubtractAmount;
                }, true);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class CommandHandler : ICommand
        {
            private readonly Action _action;
            private readonly bool _canExecute;
    
            public CommandHandler(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public void Execute(object parameter)
            {
                _action();
            }
        }
    }
