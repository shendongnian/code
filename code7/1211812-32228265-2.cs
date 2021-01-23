             public class RelayCommand<T> : IRelayCommand
    {
        private Predicate<T> _canExecute;
        private Action<T> _execute;
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
		public void Execute(T parameter)
        {
            _execute(parameter);
        }
        private bool CanExecute(T parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public virtual bool CanExecute(object parameter)
        {
            return parameter == null ? false : CanExecute((T)parameter);
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        public event EventHandler CanExecuteChanged;
        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}
        public void RaiseCanExecuteChanged()
        {
            var temp = Volatile.Read(ref CanExecuteChanged);
            if (temp != null)
                temp(this, new EventArgs());
        }
    }
    public class RelayCommand : IRelayCommand
    {
        private Func<bool> _canExecute;
        private Action _execute;
        public RelayCommand(Action execute , Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var temp = Volatile.Read(ref CanExecuteChanged);
            if (temp != null)
                temp(this, new EventArgs());
        }
        public void Execute(object parameter)
        {
            _execute();
        }
    }
         
