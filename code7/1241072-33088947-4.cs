    class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteHandler;
        private readonly Action<T> _executeHandler;
        public DelegateCommand(Action<T> executeHandler)
            : this(executeHandler, null) { }
        public DelegateCommand(Action<T> executeHandler, Func<T, bool> canExecuteHandler)
        {
            _canExecuteHandler = canExecuteHandler;
            _executeHandler = executeHandler;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler != null ? _canExecuteHandler((T)parameter) : true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _executeHandler((T)parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
