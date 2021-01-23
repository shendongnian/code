     public class RelayCommand : ICommand
        {
            private Action<object> _execute;
            private Func<object, bool> _canExecute;
    
            public RelayCommand(Action<object> execute, Func<object,bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
    
            public void Execute(object parameter)
            {
                _execute(parameter);
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }
    
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    if (_canExecute != null)
                    {
                        CommandManager.RequerySuggested += value;
                    }
                }
                remove
                {
                    if (_canExecute != null)
                    {
                        CommandManager.RequerySuggested -= value;
                    }
                }
            }
        }
