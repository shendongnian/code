      public sealed class RelayCommand : ICommand
    {
        #region Fields
        readonly Action<object> _action;
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion  Fields
        #region Constructors
        public RelayCommand(Action<object> action)
        {
            if (action != null)
                _action = action;
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion Constructors
        #region ICommand Members
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
            else
            {
                _action(parameter ?? "Command parameter is null!");
            }
        }
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
    }
