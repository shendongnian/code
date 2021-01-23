      class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Func<bool> _func;  
        public RelayCommand(Action<object> action,Func<bool> func)
        {
            _action = action;
            _func = func;
        }
        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged!=null)
                CanExecuteChanged(this,new EventArgs());
        }
        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            if (_func != null)
                _func();
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _action(parameter);
        }
        #endregion
    }
