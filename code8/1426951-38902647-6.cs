    public class RelayCommand : ICommand
        {
            #region Fields
    
            private readonly Action<object> _execute;
            private readonly Predicate<object> _canExecute;
    
            #endregion // Fields
    
            #region Constructors
    
            public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
            {
                if (execute == null)
                    throw new ArgumentNullException(nameof(execute));
    
                this._execute = execute;
                this._canExecute = canExecute;
            }
    
            #endregion // Constructors
    
            #region ICommand Members
    
            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                return this._canExecute == null || this._canExecute(parameter);
            }
    
            public event EventHandler CanExecuteChanged {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public void Execute(object parameter)
            {
                this._execute(parameter);
            }
    
            #endregion // ICommand Members
        }
